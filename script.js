document.addEventListener('DOMContentLoaded', function () {
    const expenseForm = document.getElementById('expense-form');
    const expenseTable = document.getElementById('expense-table');
    const expenseList = document.getElementById('expense-list');
    const submitBtn = document.getElementById('submit-btn');
    const updateBtn = document.getElementById('update-btn');
    const cancelBtn = document.getElementById('cancel-btn');
    let editingIndex = null;

    expenseForm.addEventListener('submit', function (event) {
        event.preventDefault();

        const description = document.getElementById('description').value;
        const amount = parseFloat(document.getElementById('amount').value);

        if (description.trim() === '' || isNaN(amount)) {
            alert('Por favor, preencha todos os campos corretamente.');
            return;
        }

        if (editingIndex !== null) {
            // Editando despesa existente
            const row = expenseList.rows[editingIndex];
            row.cells[0].textContent = description;
            row.cells[1].textContent = `R$ ${amount.toFixed(2)}`;
            editingIndex = null;
            submitBtn.style.display = 'inline';
            updateBtn.style.display = 'none';
            cancelBtn.style.display = 'none';
        } else {
            // Adicionando nova despesa
            const newRow = expenseList.insertRow();
            newRow.innerHTML = `
                <td>${description}</td>
                <td>R$ ${amount.toFixed(2)}</td>
                <td>
                    <button class="edit-btn">Editar</button>
                    <button class="delete-btn">Excluir</button>
                </td>
            `;
        }

        expenseForm.reset();
        addEditDeleteEvents();
    });

    function addEditDeleteEvents() {
        const editButtons = document.querySelectorAll('.edit-btn');
        const deleteButtons = document.querySelectorAll('.delete-btn');

        editButtons.forEach((button, index) => {
            button.addEventListener('click', function () {
                const row = expenseList.rows[index];
                const description = row.cells[0].textContent;
                const amount = parseFloat(row.cells[1].textContent.replace('R$ ', ''));

                document.getElementById('description').value = description;
                document.getElementById('amount').value = amount;

                submitBtn.style.display = 'none';
                updateBtn.style.display = 'inline';
                cancelBtn.style.display = 'inline';

                editingIndex = index;
            });
        });

        deleteButtons.forEach((button, index) => {
            button.addEventListener('click', function () {
                expenseList.deleteRow(index);
                editingIndex = null;
            });
        });
    }

    updateBtn.addEventListener('click', function () {
        expenseForm.dispatchEvent(new Event('submit'));
    });

    cancelBtn.addEventListener('click', function () {
        expenseForm.reset();
        submitBtn.style.display = 'inline';
        updateBtn.style.display = 'none';
        cancelBtn.style.display = 'none';
        editingIndex = null;
    });

    addEditDeleteEvents();
});
