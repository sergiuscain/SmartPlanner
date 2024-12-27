let subtaskIndex = 1;

document.getElementById('add-subtask').addEventListener('click', function () {
    const container = document.getElementById('subtask-container');
    const newSubtask = document.createElement('div');
    newSubtask.className = 'subtask mainColor';
    newSubtask.innerHTML = `
                <label>Название подзадачи</label><br/>
                <input type="text" name="SubTasks[${subtaskIndex}].Title" /><br/>
                <label>Описание подзадачи</label><br/>
                <input type="text" name="SubTasks[${subtaskIndex}].Description" /><br/>
            `;
    container.appendChild(newSubtask);
    subtaskIndex++;
});
