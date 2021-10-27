using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceWalker : MonoBehaviour
{
    //posicion y velocidad
    [SerializeField] private VectorPoderoso thisPosition, velocidad;

    //colores
    [Header("Colores")]
    [SerializeField] Color colorpos, colorpos2, colorvelo, coloracele;

    //colisiones con el limite del mundo
    [SerializeField] float xmax = 5f, xmin = -5, ymax = 5, ymin = -5, rapidezlimite = 5f;
    [SerializeField] bool boxlimits = true;

    //valores temporales por que aja ... mutable
    VectorPoderoso velocidadaplicada, fuerzaactual, gravedadactual, fuerzaAcumuladaActual;

    //fuerzas
    [SerializeField] VectorPoderoso fuerza1 = new VectorPoderoso(0, 0);
    [SerializeField] VectorPoderoso fuerza2 = new VectorPoderoso(0, 0);
    [SerializeField] VectorPoderoso gravedad = new VectorPoderoso(0, -9.8f);

    [SerializeField] [Range(0, 1)] float coeficienteFriccionTierra = 1f;

    //masa del cuerpo 
    [SerializeField] float N = 20f;
    [SerializeField] float masa = 1f;
    [SerializeField] bool pesoBool = true;
    private VectorPoderoso peso;

    //total de las fuerzas
    [SerializeField] VectorPoderoso fuerzaAcumulada = new VectorPoderoso(0, 0);

    //fluidos
    [SerializeField] float rho = 0f;
    [SerializeField] bool fluidoEnter = false;
    [SerializeField] float areaContacto = 0f;
    [SerializeField] [Range(0, 1)] float coeficienteFriccionFluido = 1f;

    //Friccion
    [SerializeField] bool BoolFriccion = true;

    //Gravedad
    [SerializeField] ForceWalker objetoGravitacional;
    [SerializeField] float Gmagico = 1f;
    [SerializeField] bool GravitacionActivada = true;

    private void Start()
    {
        thisPosition.X = this.transform.position.x;
        thisPosition.Y = this.transform.position.y;
    }

    void Update()
    {
        UpdatePosition();
        DrawVector();     
        transform.position = new Vector3(thisPosition.X, thisPosition.Y);
        ChekeoLimites();
    }

    public void UpdatePosition()
    {
        //Por tener mutable el cosiaco nos toco hacer esto :c
        velocidadaplicada = new VectorPoderoso(velocidad.X, velocidad.Y);

        //fuerzas
        fuerzaAcumulada.X = 0;
        fuerzaAcumulada.Y = 0;

        //Calcular Friccion
        if (BoolFriccion)
        {
            SumarFuerzas(AplicarFriccion());
        }

        //fuerza de fluidos
        FluidoEntrada();

        //Aplicacion de fuerzas
        ApplyForce(fuerza1);
        ApplyForce(fuerza2);

        if (pesoBool)
        {
            ApplyGravity();
        }

        if (GravitacionActivada)
        {
            FuerzaGravitacional(objetoGravitacional);
        }

        //copia del acumulado 
        fuerzaAcumuladaActual = new VectorPoderoso(fuerzaAcumulada.X, fuerzaAcumulada.Y);

        //sumar la aceleracion a la velocidad
        fuerzaAcumuladaActual.Multiplicar(1 / masa);

        //Aplciar aceleracion a la velocidad
        velocidad.Suma(fuerzaAcumuladaActual.Multiplicar(Time.deltaTime));


        //rapidez limite para que no sobrepase el ecceso
        if (velocidad.CalcularMagnitud() > rapidezlimite)
        {
            velocidad = velocidad.Normalizar();
            velocidad.Multiplicar(rapidezlimite);
        }

        //se le suma la veclocidad a la posicion
        thisPosition.Suma(velocidadaplicada.Multiplicar(Time.deltaTime));
    }

    private void FuerzaGravitacional(ForceWalker gravitacion)
    {
        gravitacion = gravitacion.GetComponent<ForceWalker>();

        float m2 = gravitacion.masa;
        VectorPoderoso V1 = new VectorPoderoso(thisPosition.X, thisPosition.Y);
        VectorPoderoso V2 = new VectorPoderoso(gravitacion.thisPosition.X, gravitacion.thisPosition.Y);
        VectorPoderoso diferencia = V2.Resta(V1);
        float distanciaSeparacion = diferencia.CalcularMagnitud();
        VectorPoderoso direccion = diferencia.Normalizar();
        VectorPoderoso fuerzaGravitacional = direccion.Multiplicar((Gmagico * masa * m2) / Mathf.Pow(distanciaSeparacion, 2));
        fuerzaGravitacional.DibujarVectorDiferente(V1.X, V2.Y, colorpos2);
        SumarFuerzas(fuerzaGravitacional);
    }

    private void FluidoEntrada()
    {
        if (fluidoEnter)
        {
            VectorPoderoso fuerzaFluido = new VectorPoderoso(0f, 0f);
            VectorPoderoso velocidadNormalizada = velocidad.Normalizar();
            float cuadradoV = Mathf.Pow(velocidad.CalcularMagnitud(), 2);
            fuerzaFluido = velocidadNormalizada.Multiplicar((-1f / 2f) * rho * cuadradoV * coeficienteFriccionFluido * areaContacto); 
            SumarFuerzas(fuerzaFluido);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fluido"))
        {
            fluidoEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fluido"))
        {
            fluidoEnter = false;
        }
    }

    private VectorPoderoso AplicarFriccion()
    {
        VectorPoderoso friccion = velocidad.Normalizar();
        friccion.Multiplicar(-coeficienteFriccionTierra * N);       
        return friccion;
    }

    private void ApplyForce(VectorPoderoso fuerzaAplicar)
    {
        VectorPoderoso fuerzaAplicadakun = new VectorPoderoso(fuerzaAplicar.X, fuerzaAplicar.Y);
        VectorPoderoso solucion = fuerzaAplicadakun.Multiplicar(1 / masa);
        SumarFuerzas(solucion);
    }

    private void ApplyGravity()
    {
        VectorPoderoso gravedadActual = new VectorPoderoso(gravedad.X, gravedad.Y);
        peso = gravedadActual.Multiplicar(masa);
        SumarFuerzas(peso);
    }

    private void SumarFuerzas(VectorPoderoso fuerzaExtra)
    {
        fuerzaAcumulada.Suma(fuerzaExtra);
        fuerzaExtra.DibujarVectorDiferente(thisPosition.X, thisPosition.Y, coloracele);
    }

    private void DrawVector()
    {
        thisPosition.DibujarVector(colorpos);
        velocidad.DibujarVectorDiferente(thisPosition.X, thisPosition.Y, colorvelo);
    }

    private void ChekeoLimites()
    {
        //limites de la caja
        if (boxlimits)
        {
            BoxLimitsCollision();
        }
    }

    private void BoxLimitsCollision()
    {
        if (thisPosition.X > xmax)
        {
            thisPosition.X = xmax;
            velocidad.X = -velocidad.X;
        }
        else if (thisPosition.X < xmin)
        {
            thisPosition.X = xmin;
            velocidad.X = -velocidad.X;
        }
        if (thisPosition.Y > ymax)
        {
            thisPosition.Y = ymax;
            velocidad.Y = -velocidad.Y;
        }
        else if (thisPosition.Y < ymin)
        {
            thisPosition.Y = ymin;
            velocidad.Y = -velocidad.Y;
        }
    }
}
