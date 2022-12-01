use FiapSmartCity

CREATE TABLE TIPOPESSOA (
      IDTIPO    int identity(1,1)        PRIMARY KEY,
      NOME VARCHAR(100),
      ENDERECO VARCHAR(50)  NOT NULL,
      RESIDENTE  CHAR(1)
    );
