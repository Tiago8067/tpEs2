CREATE TABLE UserModel
(
    Id uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
    Email  VARCHAR(250),
    PassHash bytea,
    PassSalt bytea,
    DataCriacao timestamp with time zone
);