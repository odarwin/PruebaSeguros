# PruebaSeguros

Herramientas:
NET CORE 5.0
Microsoft.EntityFrameworkCore" Version="5.0.17"
Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.17"
Microsoft.EntityFrameworkCore.Tools" Version="5.0.17"


Ejecutar la sentencia para crear las entidades
Scaffold-DbContext "Server=localhost; Database=db_seguros; Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

Ejecutar Scripts.sql para crear los registros.
