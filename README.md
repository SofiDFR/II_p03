# Interfaces Inteligentes: Movimientos
## Ejercicio 1
```cs
public float speed = 5f;
```
La `velocidad` es un atributo público de la clase para que se pueda modificar desde el inspector

```cs
void Update()
{
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
    transform.Translate(movement);

    if (Input.GetKey(KeyCode.UpArrow))
    {
        Debug.Log(keyCode + (speed * vertical));
    }
    else if (Input.GetKey(KeyCode.DownArrow))
    {
        Debug.Log(keyCode + (speed * vertical));
    }
    else if (Input.GetKey(KeyCode.LeftArrow))
    {
        Debug.Log(keyCode + (speed * horizontal));
    }
    else if (Input.GetKey(KeyCode.RightArrow))
    {
        Debug.Log(keyCode + (speed * horizontal));
    }
}
```
1. 

![ej_1](docs/p03_001.gif)
## Ejercicio 2
Antes de nada, se debe asignar la `tecla H` al comando `Shoot` (Disparo). Para ello vamos a `Edit > proyect Settings > Input Manager > Axes` y allí creamos uno nuevo y ponemos la siguiente información:

![tecla_shoot]()

```cs
public GameObject bulletPrefab;
public float bulletSpeed = 10f;
public Transform shootingPoint;
```
1. En el propio editor se creó un `prefab` de una bala (una esfera). Este script recibe este objeto como parámetro. Se puede arrastrar desde el inspector
2. `bulletSpeed` es la velocidad a la que saldrá disparada la bala. Se puede modificar desde el inspector
3. Y el `shootingPoint` es un objeto vacío colocado enfrente del cubo que actuará como `punto de salida para la bala`. Se asigna desde el inspector

```cs
void Update()
{
    if (Input.GetButtonDown("Shoot"))
    {
        Debug.Log("Disparo realizado");
        ExecuteShot();
    }
}
```
Si la tecla pulsada se corresponde al del comando `Shoot (H)`, muestra por consola que se ha realizado el disparo y llama a la función que lo ejecuta

```cs
void ExecuteShot()
{
    GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);

    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.velocity = shootingPoint.forward * bulletSpeed;
    }
    Debug.Log("Shot!");
}
```

![ej_1](docs/p03_002.gif)
## Ejercicio 3
## Ejercicio 4
## Ejercicio 5
## Ejercicio 6
## Ejercicio 7
## Ejercicio 8
## Ejercicio 9
## Ejercicio 10
## Ejercicio 11
## Ejercicio 12
