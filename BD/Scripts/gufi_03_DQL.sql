USE Gufi;
GO

SELECT idUsuario, tituloTipoUsuario, nomeUsuario, email FROM usuarios
INNER JOIN tiposUsuarios
ON usuarios.idTipoUsuario = tiposUsuarios.idTipoUsuario;

SELECT nomeFantasia AS [local], idEvento, nomeEvento, tituloTipoEvento AS tema, dataEvento FROM eventos
INNER JOIN instituicoes
ON eventos.idInstituicao = instituicoes.idInstituicao
INNER JOIN tiposEventos
ON eventos.idTipoEvento = tiposEventos.idTipoEvento;

-- simulador de login || se o email ou a senha estiver errado, não irá aparecer na tabela
SELECT nomeUsuario AS Nome, email AS Email FROM usuarios
WHERE email = 'lucas@lucas.com' AND senha = 'lucas123';