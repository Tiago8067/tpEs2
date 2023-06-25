CREATE TABLE tarefas
(
    id               uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
    curta_descricao  VARCHAR(250),
    data_hora_inicio timestamp with time zone,
    data_hora_fim    timestamp with time zone,
    estado_tarefa    VARCHAR(100),
    projeto_id       uuid REFERENCES projetos (id)
);
