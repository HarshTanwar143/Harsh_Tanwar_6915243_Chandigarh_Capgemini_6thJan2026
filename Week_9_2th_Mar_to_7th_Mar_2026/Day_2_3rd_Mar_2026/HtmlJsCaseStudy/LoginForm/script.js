function toggleForm() {
    const reg = document.getElementById('register-section');
    const login = document.getElementById('login-section');
    reg.style.display = reg.style.display === 'none' ? 'block' : 'none';
    login.style.display = login.style.display === 'none' ? 'block' : 'none';
}

document.getElementById('register-form').addEventListener('submit', (e) => {
    e.preventDefault();
    const user = document.getElementById('reg-user').value;
    const email = document.getElementById('reg-email').value;
    const pass = document.getElementById('reg-pass').value;
    const confirm = document.getElementById('reg-confirm').value;

    if (pass.length < 6) return alert("Password too short!");
    if (pass !== confirm) return alert("Passwords do not match!");

    const userData = { user, email, pass };
    localStorage.setItem(email, JSON.stringify(userData));
    alert("Registration Successful!");
    toggleForm();
});

document.getElementById('login-form').addEventListener('submit', (e) => {
    e.preventDefault();
    const email = document.getElementById('login-email').value;
    const pass = document.getElementById('login-pass').value;

    const storedUser = JSON.parse(localStorage.getItem(email));

    if (storedUser && storedUser.pass === pass) {
        alert(`Welcome back, ${storedUser.user}!`);
    } else {
        alert("Invalid credentials!");
    }
});