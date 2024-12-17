import React, { useEffect, useState } from 'react';
import { getStudents } from '../services/api'; // Importe a função para obter alunos
import './ListaAlunos.css';

const ListaAlunos = () => {
  const [students, setStudents] = useState([]);

  useEffect(() => {
    const fetchStudents = async () => {
      try {
        const data = await getStudents(); // Chama a função para obter os alunos
        setStudents(data); // Armazena os alunos no estado
      } catch (error) {
        console.error('Erro ao buscar alunos:', error);
      }
    };

    fetchStudents(); // Chama a função ao montar o componente
  }, []);

  return (
    <div className="container">
      <h2>Lista de Alunos</h2>
      <div className="item-grid">
        {students.map((student) => (
          <div key={student.id} className="item-card">
            <h3>{student.name}</h3>
            <p>Curso: {student.course}</p>
            <div className="item-actions">
              <button className="btn btn-view">Visualizar</button>
              <button className="btn btn-edit">Editar</button>
              <button className="btn btn-delete">Excluir</button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default ListaAlunos;
