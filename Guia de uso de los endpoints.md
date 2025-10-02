## Guía de uso de los endpoints

Base URL: `http://localhost:5215/`

Todos los endpoints están bajo el controlador `ArrayController` con la ruta base: `/api/array`.

Formato de contenido: `application/json`.

---

### 1) POST /api/array/count-zeros

Full URL: `http://localhost:5215/api/array/count-zeros`

Descripción: Cuenta la cantidad de ceros en cada fila de una matriz jagged (int[][]).

Request (body):

```json
{
  "Matriz": [[0,1,0],[2,0,3],[0,0,0]]
}
```

Response (200 OK):

```json
{
  "CerosPorFila": [2,1,3]
}
```

Notas: lanza 400 Bad Request si la matriz es nula o alguna fila es nula.

---

### 2) POST /api/array/magic-square

Full URL: `http://localhost:5215/api/array/magic-square`

Descripción: Verifica si una matriz cuadrada es un cuadrado mágico y devuelve la constante mágica cuando corresponde.

Request:

```json
{
  "Matriz": [[8,1,6],[3,5,7],[4,9,2]]
}
```

Response (ejemplo cuando es mágico):

```json
{
  "EsMagico": true,
  "ConstanteMagica": 15
}
```

Response (ejemplo cuando NO es mágico):

```json
{
  "EsMagico": false,
  "ConstanteMagica": null
}
```

Notas: devuelve false si la matriz no es cuadrada o contiene valores no positivos.

---

### 3) POST /api/array/matrix-operations

Full URL: `http://localhost:5215/api/array/matrix-operations`

Descripción: Realiza suma, resta, producto y división elemento a elemento entre dos matrices de las mismas dimensiones.

Request:

```json
{
  "MatrizA": [[4,8],[2,6]],
  "MatrizB": [[2,4],[1,3]]
}
```

Response (200 OK):

```json
{
  "Suma": [[6,12],[3,9]],
  "Resta": [[2,4],[1,3]],
  "Producto": [[8,32],[2,18]],
  "Division": [[2.0,2.0],[2.0,2.0]]
}
```

Notas: si algún elemento de `MatrizB` es 0, el valor de división correspondiente se establece en Infinity (o equivalente según el serializador). Las matrices deben tener las mismas dimensiones; en caso contrario se devuelve 400.

---

### 4) POST /api/array/identity

Full URL: `http://localhost:5215/api/array/identity`

Descripción: Genera una matriz identidad de tamaño `Size` (int > 0).

Request:

```json
{
  "Size": 3
}
```

Response (200 OK):

```json
{
  "Matriz": [[1,0,0],[0,1,0],[0,0,1]]
}
```

Notas: `Size` está decorado con el atributo de validación `MustBePositive`; si se envía un valor <= 0 se devuelve 400 Bad Request.

---

### 5) POST /api/array/matrix-statistics

Full URL: `http://localhost:5215/api/array/matrix-statistics`

Descripción: Calcula suma y promedio por fila y por columna para una matriz `int[][]`.

Request:

```json
{
  "Matriz": [[1,2,3],[4,5,6],[7,8,9]]
}
```

Response (200 OK):

```json
{
  "Estadisticas": {
    "SumaPorFila": [6,15,24],
    "PromedioPorFila": [2.0,5.0,8.0],
    "SumaPorColumna": [12,15,18],
    "PromedioPorColumna": [4.0,5.0,6.0]
  }
}
```

Notas: las filas deben tener la misma longitud; de lo contrario devuelve 400.

---

### 6) POST /api/array/sales-analysis

Full URL: `http://localhost:5215/api/array/sales-analysis`

Descripción: Analiza una matriz de ventas `int[][]` (meses x días). Devuelve venta mínima, máxima, total y ventas por día.

Request:

```json
{
  "Ventas": [[10,20,30],[5,25,15]]
}
```

Response (200 OK):

```json
{
  "VentaMinima": { "Valor": 5, "Mes": 2, "Dia": 1 },
  "VentaMaxima": { "Valor": 30, "Mes": 1, "Dia": 3 },
  "VentaTotal": 105,
  "VentaPorDia": [15,45,45]
}
```

Notas: la respuesta usa `VentaInfo` con campos `Valor`, `Mes` y `Dia` (indices 1-based para Mes/Dia).

---

### 7) POST /api/array/grades-analysis

Full URL: `http://localhost:5215/api/array/grades-analysis`

Descripción: Analiza calificaciones por alumno `double[][]` (alumnos x parciales). Devuelve promedios por alumno, promedio más alto, más bajo, cantidad de parciales reprobados y distribución.

Request:

```json
{
  "Calificaciones": [[8.5,7.0,9.0],[6.0,5.5,7.0]]
}
```

Response (200 OK):

```json
{
  "PromedioPorAlumno": [8.166666666666666,6.166666666666667],
  "PromedioMasAlto": 8.166666666666666,
  "PromedioMasBajo": 6.166666666666667,
  "ParcialesReprobados": 2,
  "DistribucionCalificaciones": {
    "0-4.9": 0,
    "5.0-5.9": 0,
    "6.0-6.9": 1,
    "7.0-7.9": 1,
    "8.0-8.9": 0,
    "9.0-10": 0
  }
}
```

Notas: el campo `ParcialesReprobados` cuenta todos los parciales (<7.0) en la matriz completa.

---

### 8) POST /api/array/reverse-array

Full URL: `http://localhost:5215/api/array/reverse-array`

Descripción: Revierte un arreglo de enteros usando recursión.

Request:

```json
{
  "ArrayToReverse": [1,2,3,4,5]
}
```

Response (200 OK):

```json
{
  "ReversedArray": [5,4,3,2,1]
}
```

---

### 9) POST /api/array/count-occurrences

Full URL: `http://localhost:5215/api/array/count-occurrences`

Descripción: Cuenta recursivamente las ocurrencias de un valor en un arreglo.

Request:

```json
{
  "Array": [1,2,3,2,2,4],
  "Value": 2
}
```

Response (200 OK):

```json
{
  "Count": 3
}
```

---

### 10) POST /api/array/flatten-stats

Full URL: `http://localhost:5215/api/array/flatten-stats`

Descripción: Aplana una matriz jagged `int[][]` y calcula estadísticas (flattened array, suma, min, max, promedio). Nota: el controlador reutiliza el DTO `CalcularEstadisticasMatrizRequest` para el body.

Request:

```json
{
  "Matriz": [[1,2],[3],[4,5]]
}
```

Response (200 OK):

```json
{
  "Flattened": [1,2,3,4,5],
  "Sum": 15,
  "Min": 1,
  "Max": 5,
  "Average": 3.0
}
```

---

Estado y notas finales

- Todos los endpoints son POST y están implementados en `src/Controllers/ArrayController.cs`.