// ============================================================
//  api.js  —  All API calls wired to LearningPlatformAPI
//  Base URL: http://localhost:5221
// ============================================================

const API_BASE = 'http://localhost:5221';

// ── helpers ──────────────────────────────────────────────────
function getToken()    { return localStorage.getItem('lp_token'); }
function getUser()     { const u = localStorage.getItem('lp_user'); return u ? JSON.parse(u) : null; }
function getUserId()   { const u = getUser(); return u ? u.id : null; }
function getRole()     { const u = getUser(); return u ? u.role : null; }
function isLoggedIn()  { return !!getToken(); }

function authHeaders() {
  const t = getToken();
  return t ? { 'Authorization': `Bearer ${t}`, 'Content-Type': 'application/json' }
           : { 'Content-Type': 'application/json' };
}

async function request(method, path, body = null) {
  const opts = { method, headers: authHeaders() };
  if (body) opts.body = JSON.stringify(body);

  const res = await fetch(`${API_BASE}${path}`, opts);

  // 204 No Content
  if (res.status === 204) return { ok: true };

  let data;
  try { data = await res.json(); } catch { data = {}; }

  if (!res.ok) {
    const msg = data?.error || data?.title || data?.message
              || Object.values(data?.errors || {}).flat().join(', ')
              || `HTTP ${res.status}`;
    throw new Error(msg);
  }
  return data;
}

// ── AUTH ─────────────────────────────────────────────────────
const Auth = {
  async register(username, email, password, role) {
    return request('POST', '/api/auth/register', { username, email, password, role });
  },

  async login(email, password) {
    const data = await request('POST', '/api/auth/login', { email, password });
    // data = { token, username, role }
    localStorage.setItem('lp_token', data.token);
    // We don't get userId from login — store what we have
    localStorage.setItem('lp_user', JSON.stringify({
      username: data.username,
      role: data.role
    }));
    return data;
  },

  logout() {
    localStorage.removeItem('lp_token');
    localStorage.removeItem('lp_user');
    localStorage.removeItem('lp_userid');
  }
};

// ── COURSES ──────────────────────────────────────────────────
const Courses = {
  getAll()               { return request('GET',  '/api/v1/courses'); },
  getById(id)            { return request('GET',  `/api/v1/courses/${id}`); },
  getByCategory(name)    { return request('GET',  `/api/v1/courses/category/${encodeURIComponent(name)}`); },
  create(dto)            { return request('POST', '/api/v1/courses', dto); },
  addLesson(courseId, dto){ return request('POST', `/api/v1/courses/${courseId}/lessons`, dto); },
};

// ── ENROLLMENT ───────────────────────────────────────────────
const Enrollments = {
  enroll(userId, courseId) {
    return request('POST', `/api/v1/enroll?userId=${userId}&courseId=${courseId}`);
  }
};
