const input = document.getElementById('todo-input');
const addBtn = document.getElementById('add-btn');
const taskList = document.getElementById('task-list');

let tasks = JSON.parse(localStorage.getItem('tasks')) || [];

function saveAndRender() {
    localStorage.setItem('tasks', JSON.stringify(tasks));
    render();
}

function render() {
    taskList.innerHTML = '';
    tasks.forEach((task, index) => {
        const li = document.createElement('li');
        li.innerHTML = `
            <div>
                <input type="checkbox" ${task.completed ? 'checked' : ''} onchange="toggleTask(${index})">
                <span class="${task.completed ? 'completed' : ''}">${task.text}</span>
            </div>
            <button class="delete-btn" onclick="deleteTask(${index})">Delete</button>
        `;
        taskList.appendChild(li);
    });
}

addBtn.onclick = () => {
    if (input.value.trim()) {
        tasks.push({ text: input.value, completed: false });
        input.value = '';
        saveAndRender();
    }
};

window.toggleTask = (index) => {
    tasks[index].completed = !tasks[index].completed;
    saveAndRender();
};

window.deleteTask = (index) => {
    tasks.splice(index, 1);
    saveAndRender();
};

render();