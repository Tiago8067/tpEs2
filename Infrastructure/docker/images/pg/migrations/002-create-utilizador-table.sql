CREATE TABLE utilizadores
(
    id                 uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
    email              VARCHAR(250),
    username           VARCHAR(100),
    password           VARCHAR(100)
);