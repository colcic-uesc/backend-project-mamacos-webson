import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Header from './components/Header';
import Nav from './components/Nav';
import Footer from './components/Footer';
import Formulario from './components/Formulario';
import ListaAlunos from './components/ListaAlunos';

const App = () => (
  <Router>
    <div style={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
      <Header />
      <Nav />
      <main style={{ flex: 1 }}>
        <Routes>
          <Route path="/" element={<Formulario />} />
          <Route path="/lista" element={<ListaAlunos />} />
        </Routes>
      </main>
      <Footer />
    </div>
  </Router>
);

export default App;
