const items = [
    { id: 1, nome: 'Aluno 1', curso: 'Computação' },
    { id: 2, nome: 'Aluno 2', curso: 'Administração' },
    { id: 3, nome: 'Aluno 3', curso: 'Direito' }
];

const itemGrid = document.getElementById('itemGrid');

items.forEach(item => {
    const itemCard = document.createElement('div');
    itemCard.classList.add('item-card');
    itemCard.innerHTML = `
        <h3>${item.nome}</h3>
        <p>Curso: ${item.curso}</p>
        <div class="item-actions">
            <a href="#" class="btn btn-view">Visualizar</a>
            <a href="#" class="btn btn-edit">Editar</a>
            <a href="#" class="btn btn-delete">Excluir</a>
        </div>
    `;
    itemGrid.appendChild(itemCard);
});
