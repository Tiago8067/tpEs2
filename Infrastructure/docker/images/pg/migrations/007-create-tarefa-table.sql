CREATE TABLE tarefas (
                         id             uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
                         curta_descricao VARCHAR(250) NOT NULL,
                         data_hora_inicio     DATE NOT NULL,
                         data_hora_fim     DATE,
                         estado_tarefa      VARCHAR(100) NOT NULL,
                         projeto_id           uuid REFERENCES projetos(id)
);