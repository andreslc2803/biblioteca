# Proyecto de Prueba Técnica - Gestión de Libros

Este proyecto es una aplicación de ejemplo para la gestión de libros, construida con **.NET 8** en el backend y **Angular 20** en el frontend. A continuación se detallan las características principales y pasos de instalación y ejecución.

---

## 1. Base de Datos

* Se utilizó **SQL Server** para la conexión y creación de tablas.
* En la carpeta `scripts` se encuentran los siguientes queries:

  * Creación de la base de datos
  * Creación de tablas
  * Inserción de datos de prueba

### Pasos para ejecutar los scripts:

1. Abrir **SQL Server Management Studio (SSMS)** o cualquier cliente SQL compatible.
2. Ejecutar el script de creación de base de datos.
3. Ejecutar el script de creación de tablas.
4. Ejecutar el script de inserción de datos.

> Asegúrate de actualizar la cadena de conexión en el backend si tu servidor SQL tiene un nombre distinto o usa autenticación diferente.

---

## 2. Backend (.NET 8)

El backend está construido con **.NET 8** y sigue la arquitectura por capas:

* **API**: Controladores para exponer los endpoints.
* **BL (Business Logic)**: Lógica de negocio.
* **DAL (Data Access Layer)**: Acceso a la base de datos mediante el **patrón Repository**.
* **Entities**: Entidades y modelos del dominio.

### Características adicionales:

* Se implementó **inyección de dependencias** para manejar los servicios y repositorios.
* Se usan **DTOs (Data Transfer Objects)** para las transferencias de datos entre capas.
* Existe una constante para limitar la cantidad máxima de libros, actualmente **20 libros**.

### Pasos para ejecutar el backend:

1. Clonar el repositorio:

   ```bash
   git clone https://github.com/andreslc2803/biblioteca.git
   ```
2. Abrir la solución `.sln` en **Visual Studio 2022+** o **VS Code**.
3. Restaurar paquetes NuGet:

   ```bash
   dotnet restore
   ```
4. Ejecutar el proyecto:

   ```bash
   dotnet run --project <ruta_del_proyecto_api>
   ```
5. El backend quedará corriendo normalmente en `https://localhost:5071` (o según tu configuración).

> Verifica que la cadena de conexión en `appsettings.json` coincida con tu servidor SQL y base de datos creada.

---

## 3. Frontend (Angular 20)

El frontend está construido con **Angular 20** y utiliza **Angular Material**.

### Características:

* Diferentes **componentes** para la gestión de libros y pruebas de la API.
* **Interceptor** para manejar errores personalizados de la API.
* Consumo de servicios mediante HTTP hacia el backend.
* Configuración de **ruteo** para navegar entre los diferentes componentes.

### Configuración de la API:

* En la carpeta `src/environments` existe el archivo `environment.ts`:

  ```ts
  export const environment = {
    production: false,
    apiUrl: 'https://localhost:5071/api' // URL del backend
  };
  ```
* Asegúrate de actualizar `apiUrl` con la URL donde se ejecuta tu backend.

### Pasos para ejecutar el frontend:

1. Clonar el repositorio:

   El repositorio esta alojado tanto el back como el front, solo es necesario clonarlo una vez
   
2. Instalar dependencias de Angular:

   ```bash
   npm install
   ```
3. Ejecutar la aplicación:

   ```bash
   ng serve
   ```
4. Abrir el navegador en `http://localhost:4200` para acceder a la aplicación.

---

## Nota Final

* Asegúrate de tener **SQL Server**, **.NET 8 SDK** y **Node.js** instalados.
* Sigue los pasos en orden: primero la base de datos, luego el backend, y finalmente el frontend.
* La aplicación está preparada para pruebas de consumo de API y validaciones de negocio según la cantidad máxima de libros.

---

## Autor

* Proyecto desarrollado por **Andres Londoño Carvajal**