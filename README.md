# 🗂️ APICategory

API REST para la gestión de categorías, construida con ASP.NET Core 8 y Entity Framework Core.

## 🚀 Características

- Crear, obtener por ID, actualizar y eliminar categorías.
- Arquitectura con capas (DbContext, Repositorio, Controlador).
- Uso de Entity Framework Core (Code First).
- Base de datos SQL Server.

## 🔧 Tecnologías utilizadas

- ASP.NET Core 8  
- Entity Framework Core 8  
- SQL Server  
- Swagger (para documentación y pruebas)

## 📌 Endpoints principales

- `GET /api/category/GetCategories` → Listar todas las categorías  
- `GET /api/category/GetCategoryById/{id}` → Obtener categoría por ID  
- `POST /api/category/CreateCategory` → Crear nueva categoría  
- `PUT /api/category/UpdateCategory` → Actualizar categoría existente  
- `DELETE /api/category/DeleteCategory/{id}` → Eliminar categoría por ID

## ⚙️ Configuración del proyecto

1. Asegúrate de tener **SQL Server** instalado y ejecutándose.
2. Configura la cadena de conexión en `appsettings.json` si es necesario:

```json
"ConnectionStrings": {
  "CategoryDB": "Server=localhost;Initial Catalog=ApiCategory;Trusted_Connection=True;"
} 
```

3. Ejecuta las migraciones y crea la base de datos:
```bash
dotnet ef migrations add Initial
dotnet ef database update
```

