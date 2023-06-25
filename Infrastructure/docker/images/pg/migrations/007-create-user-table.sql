CREATE TABLE UserModel
(
    Id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
    Nome  VARCHAR(250),
    HorasDiarias FLOAT,
    Email  VARCHAR(250),
    PassHash bytea,
    PassSalt bytea,
    DataCriacao timestamp with time zone,

    Role  VARCHAR(250)
);