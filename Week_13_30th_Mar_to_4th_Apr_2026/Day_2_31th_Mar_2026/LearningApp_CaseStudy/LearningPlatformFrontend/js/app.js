// ============================================================
//  app.js  —  UI logic, routing, role-based rendering
// ============================================================

// ── Toast Notifications ──────────────────────────────────────
function toast(msg, type = 'info') {
  const c = document.getElementById('toast-container');
  const t = document.createElement('div');
  t.className = `toast ${type}`;
  t.textContent = msg;
  c.appendChild(t);
  setTimeout(() => t.remove(), 3500);
}

// ── Page Router ──────────────────────────────────────────────
function showPage(id) {
  document.querySelectorAll('.page').forEach(p => p.classList.remove('active'));
  const el = document.getElementById(id);
  if (el) el.classList.add('active');

  // update nav active state
  document.querySelectorAll('.nav-links a[data-page]').forEach(a => {
    a.classList.toggle('active', a.dataset.page === id);
  });
}

// ── Navbar Rendering ─────────────────────────────────────────
function renderNav() {
  const loggedIn = isLoggedIn();
  const user = getUser();
  const role = getRole();

  document.getElementById('nav-guest').style.display    = loggedIn ? 'none' : 'flex';
  document.getElementById('nav-logged').style.display   = loggedIn ? 'flex' : 'none';

  if (loggedIn && user) {
    document.getElementById('nav-username').textContent = user.username;
    document.getElementById('nav-role-badge').textContent = role?.toUpperCase();

    // Show "Create Course" only for Instructor / Admin
    const createLink = document.getElementById('nav-create-course');
    createLink.style.display = (role === 'Instructor' || role === 'Admin') ? 'inline-flex' : 'none';
  }
}

// ── Login / Register Form ─────────────────────────────────────
function initAuthPage() {
  // Tab switching
  document.querySelectorAll('.tab-btn').forEach(btn => {
    btn.addEventListener('click', () => {
      document.querySelectorAll('.tab-btn').forEach(b => b.classList.remove('active'));
      btn.classList.add('active');
      document.querySelectorAll('.tab-panel').forEach(p => p.classList.remove('active'));
      document.getElementById(btn.dataset.target).classList.add('active');
    });
  });

  // ── LOGIN ──
  document.getElementById('login-form').addEventListener('submit', async e => {
    e.preventDefault();
    clearErrors('login');

    const email    = document.getElementById('login-email').value.trim();
    const password = document.getElementById('login-password').value;

    let valid = true;
    if (!email)               { showError('login-email-err',    'Email is required'); valid = false; }
    else if (!isValidEmail(email)) { showError('login-email-err', 'Enter a valid email'); valid = false; }
    if (!password)            { showError('login-pass-err',     'Password is required'); valid = false; }
    if (!valid) return;

    const btn = e.target.querySelector('button[type=submit]');
    btn.disabled = true; btn.textContent = 'Signing in…';

    try {
      const data = await Auth.login(email, password);
      toast(`Welcome back, ${data.username}! 👋`, 'success');
      renderNav();
      showPage('page-courses');
      loadCourses();
    } catch (err) {
      showError('login-general-err', err.message);
    } finally {
      btn.disabled = false; btn.textContent = 'Sign In';
    }
  });

  // ── REGISTER ──
  document.getElementById('register-form').addEventListener('submit', async e => {
    e.preventDefault();
    clearErrors('register');

    const username = document.getElementById('reg-username').value.trim();
    const email    = document.getElementById('reg-email').value.trim();
    const password = document.getElementById('reg-password').value;
    const role     = document.getElementById('reg-role').value;

    let valid = true;
    if (!username)             { showError('reg-username-err', 'Username is required'); valid = false; }
    if (!email)                { showError('reg-email-err',    'Email is required'); valid = false; }
    else if (!isValidEmail(email)) { showError('reg-email-err', 'Enter a valid email'); valid = false; }
    if (!password)             { showError('reg-pass-err',     'Password is required'); valid = false; }
    else if (password.length < 6) { showError('reg-pass-err', 'Minimum 6 characters'); valid = false; }
    if (!role)                 { showError('reg-role-err',     'Select a role'); valid = false; }
    if (!valid) return;

    const btn = e.target.querySelector('button[type=submit]');
    btn.disabled = true; btn.textContent = 'Creating account…';

    try {
      await Auth.register(username, email, password, role);
      toast('Account created! Please sign in.', 'success');
      // Switch to login tab
      document.querySelector('[data-target="tab-login"]').click();
      document.getElementById('login-email').value = email;
    } catch (err) {
      showError('reg-general-err', err.message);
    } finally {
      btn.disabled = false; btn.textContent = 'Create Account';
    }
  });
}

// ── Courses Page ─────────────────────────────────────────────
let allCourses = [];

async function loadCourses() {
  const grid = document.getElementById('courses-grid');
  grid.innerHTML = '<div class="spinner"></div>';
  try {
    allCourses = await Courses.getAll();
    renderCourseGrid(allCourses);
  } catch (err) {
    grid.innerHTML = `<div class="alert alert-danger">Failed to load courses: ${err.message}</div>`;
  }
}

function renderCourseGrid(courses) {
  const grid = document.getElementById('courses-grid');
  const role = getRole();
  const loggedIn = isLoggedIn();

  if (!courses.length) {
    grid.innerHTML = `<div class="empty-state"><div class="icon">📚</div><h3>No courses yet</h3><p>Check back soon!</p></div>`;
    return;
  }

  grid.innerHTML = courses.map(c => `
    <div class="course-card">
      <div class="course-card-banner"></div>
      <div class="course-card-body">
        <span class="course-badge">${c.category || 'General'}</span>
        <h3>${escHtml(c.title)}</h3>
        <p>${escHtml(c.description || 'No description provided.')}</p>
      </div>
      <div class="course-card-footer">
        <button class="btn btn-outline" style="flex:1" onclick="viewCourse(${c.id})">View Details</button>
        ${loggedIn && role === 'Student'
          ? `<button class="btn btn-success" style="flex:1" onclick="enrollCourse(${c.id}, '${escHtml(c.title)}')">Enroll</button>`
          : ''}
        ${loggedIn && (role === 'Instructor' || role === 'Admin')
          ? `<button class="btn btn-primary" style="flex:1" onclick="openAddLessonModal(${c.id}, '${escHtml(c.title)}')">+ Lesson</button>`
          : ''}
      </div>
    </div>
  `).join('');
}

// search + category filter
function initCoursesToolbar() {
  document.getElementById('course-search').addEventListener('input', filterCourses);
  document.getElementById('category-filter').addEventListener('change', filterCourses);
}

function filterCourses() {
  const q   = document.getElementById('course-search').value.toLowerCase();
  const cat = document.getElementById('category-filter').value;
  const filtered = allCourses.filter(c =>
    (c.title?.toLowerCase().includes(q) || c.description?.toLowerCase().includes(q)) &&
    (cat === '' || c.category === cat)
  );
  renderCourseGrid(filtered);
}

// ── View Course Detail ────────────────────────────────────────
async function viewCourse(id) {
  showPage('page-course-detail');
  const container = document.getElementById('course-detail-content');
  container.innerHTML = '<div class="spinner"></div>';

  try {
    const c = await Courses.getById(id);
    const role = getRole();
    const loggedIn = isLoggedIn();

    container.innerHTML = `
      <div class="course-detail-header">
        <span class="course-badge" style="background:rgba(255,255,255,0.2);color:white">${escHtml(c.category || 'General')}</span>
        <h1>${escHtml(c.title)}</h1>
        <p>${escHtml(c.description || '')}</p>
      </div>

      ${loggedIn && role === 'Student' ? `
        <div style="margin-bottom:1.5rem">
          <button class="btn btn-success" onclick="enrollCourse(${c.id}, '${escHtml(c.title)}')">
            ✅ Enroll in this Course
          </button>
        </div>
      ` : ''}

      ${loggedIn && (role === 'Instructor' || role === 'Admin') ? `
        <div style="margin-bottom:1.5rem">
          <button class="btn btn-primary" onclick="openAddLessonModal(${c.id}, '${escHtml(c.title)}')">
            + Add Lesson
          </button>
        </div>
      ` : ''}

      <h2 style="margin-bottom:1rem;font-size:1.1rem">Lessons (${(c.lessons || []).length})</h2>
      ${(c.lessons && c.lessons.length) ? `
        <ul class="lessons-list">
          ${c.lessons.map((l, i) => `
            <li class="lesson-item">
              <div class="lesson-num">${i + 1}</div>
              <div>
                <strong>${escHtml(l.title)}</strong>
                ${l.content ? `<p style="color:var(--muted);font-size:0.85rem;margin-top:0.2rem">${escHtml(l.content)}</p>` : ''}
              </div>
            </li>
          `).join('')}
        </ul>
      ` : `<p style="color:var(--muted)">No lessons added yet.</p>`}
    `;
  } catch (err) {
    container.innerHTML = `<div class="alert alert-danger">${err.message}</div>`;
  }
}

// ── Enroll (Student only) ─────────────────────────────────────
async function enrollCourse(courseId, title) {
  if (!isLoggedIn()) { toast('Please login first', 'error'); showPage('page-auth'); return; }

  const role = getRole();
  if (role !== 'Student') {
    toast('Only Students can enroll in courses', 'error');
    return;
  }

  // We need userId — stored after login if available
  const userId = localStorage.getItem('lp_userid');
  if (!userId) {
    // Prompt for userId (limitation of this API — it doesn't return userId on login)
    openEnrollModal(courseId, title);
    return;
  }

  doEnroll(userId, courseId, title);
}

function openEnrollModal(courseId, title) {
  document.getElementById('enroll-course-title').textContent = title;
  document.getElementById('enroll-course-id-hidden').value = courseId;
  document.getElementById('enroll-userid-input').value = '';
  document.getElementById('enroll-userid-err').textContent = '';
  openModal('modal-enroll');
}

document.addEventListener('DOMContentLoaded', () => {
  document.getElementById('enroll-confirm-btn').addEventListener('click', async () => {
    const userId   = document.getElementById('enroll-userid-input').value.trim();
    const courseId = document.getElementById('enroll-course-id-hidden').value;
    const title    = document.getElementById('enroll-course-title').textContent;

    if (!userId || isNaN(userId)) {
      document.getElementById('enroll-userid-err').textContent = 'Enter a valid numeric User ID';
      return;
    }
    localStorage.setItem('lp_userid', userId);
    closeModal('modal-enroll');
    doEnroll(userId, courseId, title);
  });
});

async function doEnroll(userId, courseId, title) {
  try {
    await Enrollments.enroll(userId, courseId);
    toast(`✅ Successfully enrolled in "${title}"!`, 'success');
  } catch (err) {
    toast(err.message, 'error');
  }
}

// ── Create Course (Instructor/Admin only) ─────────────────────
function initCreateCoursePage() {
  document.getElementById('create-course-form').addEventListener('submit', async e => {
    e.preventDefault();
    clearErrors('cc');

    const role = getRole();
    if (!isLoggedIn() || (role !== 'Instructor' && role !== 'Admin')) {
      toast('Only Instructors can create courses', 'error');
      return;
    }

    const title       = document.getElementById('cc-title').value.trim();
    const category    = document.getElementById('cc-category').value.trim();
    const description = document.getElementById('cc-description').value.trim();

    let valid = true;
    if (!title) { showError('cc-title-err', 'Title is required'); valid = false; }
    if (!valid) return;

    const btn = e.target.querySelector('button[type=submit]');
    btn.disabled = true; btn.textContent = 'Creating…';

    try {
      const created = await Courses.create({ title, category, description });
      toast(`Course "${created.title}" created!`, 'success');
      e.target.reset();
      allCourses = [];           // invalidate cache
      showPage('page-courses');
      loadCourses();
    } catch (err) {
      showError('cc-general-err', err.message);
    } finally {
      btn.disabled = false; btn.textContent = 'Create Course';
    }
  });
}

// ── Add Lesson Modal ──────────────────────────────────────────
function openAddLessonModal(courseId, courseTitle) {
  document.getElementById('lesson-course-title').textContent = courseTitle;
  document.getElementById('lesson-course-id-hidden').value = courseId;
  document.getElementById('lesson-title-input').value = '';
  document.getElementById('lesson-content-input').value = '';
  document.getElementById('lesson-title-err').textContent = '';
  openModal('modal-add-lesson');
}

document.addEventListener('DOMContentLoaded', () => {
  document.getElementById('lesson-submit-btn').addEventListener('click', async () => {
    const courseId = document.getElementById('lesson-course-id-hidden').value;
    const title    = document.getElementById('lesson-title-input').value.trim();
    const content  = document.getElementById('lesson-content-input').value.trim();
    const errEl    = document.getElementById('lesson-title-err');

    if (!title) { errEl.textContent = 'Lesson title is required'; return; }
    errEl.textContent = '';

    const btn = document.getElementById('lesson-submit-btn');
    btn.disabled = true; btn.textContent = 'Saving…';

    try {
      await Courses.addLesson(courseId, { title, content, courseId: parseInt(courseId) });
      toast('Lesson added successfully!', 'success');
      closeModal('modal-add-lesson');
      // Refresh detail if on detail page
      if (document.getElementById('page-course-detail').classList.contains('active')) {
        viewCourse(courseId);
      }
      allCourses = []; // invalidate cache
    } catch (err) {
      errEl.textContent = err.message;
    } finally {
      btn.disabled = false; btn.textContent = 'Add Lesson';
    }
  });
});

// ── Modal helpers ─────────────────────────────────────────────
function openModal(id)  { document.getElementById(id).classList.add('open'); }
function closeModal(id) { document.getElementById(id).classList.remove('open'); }

// ── Form helper utils ─────────────────────────────────────────
function showError(id, msg) {
  const el = document.getElementById(id);
  if (el) el.textContent = msg;
}
function clearErrors(prefix) {
  document.querySelectorAll(`[id^="${prefix}-"][id$="-err"]`).forEach(e => e.textContent = '');
}
function isValidEmail(e) { return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(e); }
function escHtml(str) {
  return String(str || '').replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;').replace(/"/g,'&quot;');
}

// ── Bootstrap ─────────────────────────────────────────────────
document.addEventListener('DOMContentLoaded', () => {
  renderNav();
  initAuthPage();
  initCoursesToolbar();
  initCreateCoursePage();

  // Nav routing
  document.querySelectorAll('[data-page]').forEach(el => {
    el.addEventListener('click', e => {
      e.preventDefault();
      const pageId = el.dataset.page;

      if (pageId === 'page-create-course') {
        if (!isLoggedIn()) { toast('Login first!', 'error'); showPage('page-auth'); return; }
        const role = getRole();
        if (role !== 'Instructor' && role !== 'Admin') {
          toast('Only Instructors can create courses', 'error');
          return;
        }
      }

      showPage(pageId);
      if (pageId === 'page-courses') loadCourses();
    });
  });

  // Logout
  document.getElementById('btn-logout').addEventListener('click', () => {
    Auth.logout();
    toast('Logged out successfully', 'info');
    renderNav();
    showPage('page-auth');
  });

  // Close modals on overlay click
  document.querySelectorAll('.modal-overlay').forEach(overlay => {
    overlay.addEventListener('click', e => {
      if (e.target === overlay) overlay.classList.remove('open');
    });
  });

  // Back button on detail page
  document.getElementById('btn-back-courses').addEventListener('click', () => {
    showPage('page-courses');
    loadCourses();
  });

  // Start: show courses if logged in, else auth page
  if (isLoggedIn()) {
    showPage('page-courses');
    loadCourses();
  } else {
    showPage('page-auth');
  }
});
