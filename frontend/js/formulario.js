document.getElementById('academicForm').addEventListener('submit', function(e) {
    e.preventDefault();
    
    // Simulação de validação
    const nome = document.getElementById('nome').value;
    const email = document.getElementById('email').value;
    const telefone = document.getElementById('telefone').value;
    const senha = document.getElementById('senha').value;
    const curso = document.getElementById('curso').value;
    const turno = document.querySelector('input[name="turno"]:checked');
    const interesses = document.querySelector('input[name="interesses"]:checked');
    const observacoes = document.getElementById('observacoes').value;

    if (nome && email && telefone && senha && curso && turno && interesses && observacoes) {
        alert('Formulário enviado com sucesso!');
        // Aqui você poderia redirecionar para outra página ou fazer outras ações
    } else {
        alert('Por favor, preencha todos os campos obrigatórios.');
    }
});
