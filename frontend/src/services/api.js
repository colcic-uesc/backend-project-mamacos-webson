const API_URL = 'http://localhost:5207/api/student'; 

// Função para criar um novo aluno
export const createStudent = async (studentData) => {
  try {
    const response = await fetch(API_URL, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(studentData),
    });

    if (!response.ok) {
      throw new Error('Erro ao adicionar o aluno'); 
    }

    const data = await response.json();
    return data;
  } catch (error) {
    console.error('Erro:', error);
    throw error;
  }
};

// Função para obter a lista de alunos
export const getStudents = async () => {
  try {
    const response = await fetch(API_URL);
    
    if (!response.ok) {
      throw new Error('Erro ao buscar os alunos');
    }

    const data = await response.json();
    return data;
  } catch (error) {
    console.error('Erro:', error);
    throw error;
  }
};
