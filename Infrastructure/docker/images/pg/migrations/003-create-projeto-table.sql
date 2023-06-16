CREATE TABLE projetos
(
    id             uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
    nome           VARCHAR(250),
    nome_cliente   VARCHAR(250),
    preco_por_hora FLOAT,
    utilizador_id  uuid REFERENCES utilizadores (id)
);
