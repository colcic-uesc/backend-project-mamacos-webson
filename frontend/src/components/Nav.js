import React from 'react';
import { Link } from 'react-router-dom';

const Nav = () => (
  <nav style={{ backgroundColor: '#0056b3', padding: '10px', textAlign: 'center' }}>
    <Link to="/lista" style={{ color: 'white', textDecoration: 'none', margin: '0 15px' }}>Lista de Alunos</Link>
    <Link to="/" style={{ color: 'white', textDecoration: 'none', margin: '0 15px' }}>Formulário</Link>
  </nav>
);

export default Nav;
