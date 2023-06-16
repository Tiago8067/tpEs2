CREATE TABLE utilizadores
(
    id                 uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
    email              VARCHAR(250),
    username           VARCHAR(100),
    password           VARCHAR(100),
    nome               VARCHAR(250),
    genero             VARCHAR(250),
    data_de_nascimento DATE,
    codigo_postal      VARCHAR(100),
    morada             VARCHAR(100),
    tipo_utilizador    VARCHAR(100),
    estado_utilizador  VARCHAR(100)
);