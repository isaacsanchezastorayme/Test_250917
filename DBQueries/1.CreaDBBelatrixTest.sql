if not exists(select * from sys.databases where name = 'BelatrixTest')
create database BelatrixTest
go

use BelatrixTest
go

IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[T_MODULO]') AND type in (N'U') )

create table T_MODULO(
MODULO_ID INT NOT NULL PRIMARY KEY,
MODULO_DESCRIPCION VARCHAR(200),
MODULO_URL VARCHAR(200),
MODULO_ESTADO INT,
MODULO_OBSERVACION VARCHAR(200)
)
GO

INSERT INTO T_MODULO (MODULO_ID, MODULO_DESCRIPCION, MODULO_URL, MODULO_ESTADO, MODULO_OBSERVACION)
VALUES (1, 'PORTAL', '', 1, 'Belatrix test uno')
GO

IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'uspObtenerModulos'
            AND type = 'P'
      )
     DROP PROCEDURE dbo.uspObtenerModulos
GO

CREATE PROCEDURE [dbo].[uspObtenerModulos]    
(    
 @codModulo INT    
)    
AS    
DECLARE @V_COD_PERFIL INT    
  
SET NOCOUNT ON    

SELECT 
MODULO_ID,
MODULO_DESCRIPCION,
MODULO_URL,
MODULO_ESTADO,
MODULO_OBSERVACION
FROM 
T_MODULO
WHERE  MODULO_ID =  @codModulo  
   
SET NOCOUNT OFf    

GO


exec uspObtenerModulos 1