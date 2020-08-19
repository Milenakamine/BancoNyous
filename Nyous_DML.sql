INSERT INTO Acesso (Tipo) VALUES ('Padrao');
INSERT INTO Categoria (Titulo) VALUES ('Palestra');
INSERT INTO Localizacao (Logradouro, Numero, Bairro, Cidade, UF, CEP) VALUES ('Rua Luis Botta', '125', 'Sao Mateus', 'Sao Paulo', 'SP', '03959-000');
INSERT INTO Usuario (Nome, Email, Senha, DataNascimento, IdAcesso) VALUES ('Milena Akamine', 'milena@gmail.com', '4562315', '1958-10-02T06:45:00', 1);
INSERT INTO Evento (DataEvento, Capacidade, AcessoRestrito, IdCategoria, IdLocalizacao) VALUES ('2020-12-25T23:59:00', 500, 0, 4, 1);

--DELETE FROM Categoria WHERE IdCategoria= 1;
SELECT * FROM Acesso;
SELECT * FROM Categoria;
SELECT * FROM Localizacao;
SELECT * FROM Usuario;
SELECT * FROM Evento;
SELECT * FROM Localizacao;

SELECT Usuario.Nome, Usuario.Email, Acesso.Tipo AS PermissaoAcesso FROM Usuario
	INNER JOIN Acesso ON Usuario.IdAcesso = Acesso.IdAcesso;

SELECT * FROM Evento
	INNER JOIN Categoria ON Evento.IdCategoria = Categoria.IdCategoria
	INNER JOIN Localizacao ON Evento.IdLocalizacao = Localizacao.IdLocalizacao
