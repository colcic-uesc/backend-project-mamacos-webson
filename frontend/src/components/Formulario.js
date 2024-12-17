import React, { useState } from 'react';
import { createStudent } from '../services/api'; // Importe a função de conexão com a API
import './Formulario.css';

const Formulario = () => {
  const [formData, setFormData] = useState({
    registration: '',
    name: '',
    email: '',
    course: '',
    bio: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const { registration, name, email, course, bio } = formData;

    if (registration && name && email && course && bio) {
      try {
        // Chama a função que envia os dados para a API
        await createStudent({
          registration, // "registration": registration,
          name,         // "name": name,
          email,        // "email": email,
          course,       // "course": course,
          bio,          // "bio": bio,
        });
        alert('Formulário enviado com sucesso!');
        // Limpa o formulário após o envio
        setFormData({ registration: '', name: '', email: '', course: '', bio: '' });
      } catch (error) {
        alert('Erro ao enviar o formulário. Tente novamente.');
      }
    } else {
      alert('Por favor, preencha todos os campos obrigatórios.');
    }
  };

  return (
    <div className="container">
      <h2>Cadastro de Aluno</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="registration">Registro</label>
          <input
            type="text"
            id="registration"
            name="registration"
            value={formData.registration}
            onChange={handleChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="name">Nome</label>
          <input
            type="text"
            id="name"
            name="name"
            value={formData.name}
            onChange={handleChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="email">E-mail</label>
          <input
            type="email"
            id="email"
            name="email"
            value={formData.email}
            onChange={handleChange}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="course">Curso</label>
          <select
            id="course"
            name="course"
            value={formData.course}
            onChange={handleChange}
            required
          >
            <option value="">Selecione um curso</option>
            <option value="cc">Ciência da Computação</option>
            <option value="ads">Análise e Desenvolvimento de Sistemas</option>
            <option value="si">Sistemas de Informação</option>
          </select>
        </div>

        <div className="form-group">
          <label htmlFor="bio">Biografia</label>
          <textarea
            id="bio"
            name="bio"
            rows="4"
            value={formData.bio}
            onChange={handleChange}
            required
          ></textarea>
        </div>

        <button type="submit" className="btn-submit">Enviar</button>
      </form>
    </div>
  );
};

export default Formulario;
