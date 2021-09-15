SELECT c.Id, 
        c.Nome, 
        c.Telefone,
        e.Logradouro AS Enderecos_Logradouro, 
        e.Bairro AS Enderecos_Bairro,
        e.Numero AS Enderecos_Numero, 
        e.Cep AS Enderecos_Cep 
FROM dbo.Clientes c 
INNER JOIN dbo.Enderecos e
    ON e.ClienteId = c.Id 
ORDER BY c.Nome, e.Logradouro