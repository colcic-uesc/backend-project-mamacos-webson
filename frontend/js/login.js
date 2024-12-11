document.getElementById('loginForm').addEventListener('submit', function(e) {
    e.preventDefault();
    
    // Para este exemplo, qualquer entrada permitirá o acesso
    window.location.href = 'lista-itens.html';
});
