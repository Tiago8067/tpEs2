CREATE TABLE utilizadores (
                         id             uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
                         email     VARCHAR(250) NOT NULL,
                         username      VARCHAR(100) NOT NULL,
                         password      VARCHAR(100) NOT NULL,
                         nome      VARCHAR(250) NOT NULL,
                         genero      VARCHAR(250) NOT NULL,
                         data_de_nascimento     DATE NOT NULL,
                         codigo_postal     VARCHAR(100) NOT NULL,
                         morada     VARCHAR(100) NOT NULL,
                         tipo_utilizador      VARCHAR(100) NOT NULL,
                         estado_utilizador      VARCHAR(100) NOT NULL
);