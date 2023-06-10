CREATE TABLE projetos (
                         id             uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
                         nome      VARCHAR(250) NOT NULL,
                         nome_cliente      VARCHAR(250) NOT NULL,
                         preco_por_hora     FLOAT NOT NULL,
                         utilizador_id           uuid REFERENCES utilizadores(id)
);