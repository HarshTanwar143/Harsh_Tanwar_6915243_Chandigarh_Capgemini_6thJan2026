const questions = [
    { q: "What is 2 + 2?", a: ["3", "4", "5", "6"], correct: 1 },
    { q: "Capital of France?", a: ["Berlin", "London", "Paris", "Rome"], correct: 2 },
    { q: "Which is a JS Framework?", a: ["React", "Django", "Laravel", "Flask"], correct: 0 }
];

let currentIdx = 0;
let score = 0;
let timeLeft = 10;
let timer;

function startTimer() {
    timeLeft = 10;
    document.getElementById('timer').innerText = `Time: ${timeLeft}s`;
    timer = setInterval(() => {
        timeLeft--;
        document.getElementById('timer').innerText = `Time: ${timeLeft}s`;
        if (timeLeft <= 0) {
            clearInterval(timer);
            showNext();
        }
    }, 1000);
}

function loadQuestion() {
    clearInterval(timer);
    startTimer();
    const qData = questions[currentIdx];
    document.getElementById('question').innerText = qData.q;
    const optionsDiv = document.getElementById('options');
    optionsDiv.innerHTML = '';
    
    qData.a.forEach((opt, i) => {
        const btn = document.createElement('button');
        btn.className = 'opt-btn';
        btn.innerText = opt;
        btn.onclick = () => checkAnswer(i, btn);
        optionsDiv.appendChild(btn);
    });
}

function checkAnswer(selected, btn) {
    clearInterval(timer);
    const correctIdx = questions[currentIdx].correct;
    const allBtns = document.querySelectorAll('.opt-btn');
    
    if (selected === correctIdx) {
        btn.classList.add('correct');
        score++;
    } else {
        btn.classList.add('wrong');
        allBtns[correctIdx].classList.add('correct');
    }
    
    allBtns.forEach(b => b.disabled = true);
    document.getElementById('next-btn').style.display = 'block';
}

document.getElementById('next-btn').onclick = showNext;

function showNext() {
    currentIdx++;
    document.getElementById('next-btn').style.display = 'none';
    if (currentIdx < questions.length) {
        loadQuestion();
    } else {
        document.querySelector('.quiz-container').innerHTML = `<h2>Quiz Over! Score: ${score}/${questions.length}</h2>`;
    }
}

loadQuestion();