document.addEventListener('DOMContentLoaded', function () {
    const token = localStorage.getItem('token');
    const role = localStorage.getItem('role');
    const fullName = localStorage.getItem('fullName');

    const navAuthLinks = document.getElementById('navAuthLinks');
    const navUserInfo = document.getElementById('navUserInfo');
    const navAdminLinks = document.getElementById('navAdminLinks');
    const navMyBookings = document.getElementById('navMyBookings');
    const navUserName = document.getElementById('navUserName');

    if (token) {
        if (navAuthLinks) navAuthLinks.style.display = 'none';
        if (navUserInfo) navUserInfo.style.display = 'inline';
        if (navUserName) navUserName.textContent = `Hi, ${fullName || 'User'}`;

        if (role === 'Admin') {
            if (navAdminLinks) navAdminLinks.style.display = 'inline';
        } else {
            if (navMyBookings) navMyBookings.style.display = 'inline';
        }
    }
});

function logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    localStorage.removeItem('fullName');
    localStorage.removeItem('userId');
    window.location.href = '/Auth/Login';
}
