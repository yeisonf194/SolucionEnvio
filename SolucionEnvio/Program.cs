using System;
using System.Linq;

namespace Delegados
{
    class Program
    {
        static void Main(string[] args)
        {
            //Delegados
            //Se definen con func<int,int> donde el primer valor es el que retorna, y los siguientes los parametros que recibe
            //Un delegado siempr retorna algo
            //Func<double, double> exp = CalcularExponente;
            //Console.WriteLine($"Resultado: {exp}");

            //Func<int,int> doble


            Proyecto project = new Proyecto();
            project.proyectos = project.AgregarProyecto2();
            var proys = project.proyectos;





            //Consultas con LinQ
            //Una consulta no hace sobre la clase sino sobre la lista que tenga los datos



            //1.Obtener todos los proyectos cuya duracion sea mayor a 6 y menor a 12
            var rango = proys.Where(x => x.Duracion >= 6 && x.Duracion <= 12).ToList();
            //project.ImprimirProyectos(rango);






            //2.Obtener todos los proyectos que empiezen por b
            var projectsB = from p in proys
                            where (p.Nombre.StartsWith("B"))
                            select p;
            //project.ImprimirProyectos(projectsB.ToList());






            //3.Obtener todos los proyectos cuyo codigo sea multiplo de 7
            var multiplos = proys.Where(x => x.Codigo % 7 == 0).ToList();
            //project.ImprimirProyectos(multiplos);






            //4.Agrupar los proyectos que tengan duracion inferior a seis superior a seis y menor a diez y los que sean mayores a 10
            var gruposProy = proys.GroupBy(x => {
                if (x.Duracion < 6) {
                    return "Son menores que 6";
                } else if(x.Duracion >= 6 && x.Codigo<10){
                    return "Estan entre 6 y 10";
                } else if (x.Duracion >= 10) {
                    return "Es mayor que 10";
                } else {
                    return "No hay datos en este rango";
                }
            });
            //foreach (var agrupando in gruposProy) {
            //    Console.WriteLine($"Grupo de proyectos {agrupando.Key}");
            //    foreach(var item in agrupando) {
            //        Console.WriteLine($"***El nombre del proyecto {item.Nombre}***");
            //        Console.WriteLine($"La duracion del proyecto {item.Duracion}");
            //        Console.WriteLine("-");
            //    }
            //}




            //5.Obtener el promedio de la duracion de todos los proyectos
            var promedio = proys.Average(x => x.Duracion);
            //Console.WriteLine($"El promedio de los proyectos es: {promedio}");



            //6.Obtener el nombre del proyeccto con mas duracion
            var maximo = proys.Max(x => x.Duracion);
            var maxNombre = (from p in proys
                             where (p.Duracion == maximo)
                             select p.Nombre).FirstOrDefault();
            Console.WriteLine($"El maximo de todos los proyectos es: {maxNombre}");




            //7.Seleccionar el nombre y el area del proyecto con duracion mayor a seis, con firtsordefault
            var mayor6 = proys.Where(x => x.Duracion > 6).ToList();




            //8.Verificar si existe un proyecto con una duracion mayor a 24 con any
            //9.Sumar las duraciones de los proyectos cuyo codigo sea superior a 20
            //10.Tomar los 2 primeros proyectos cuyo codigo sea superior a 30


        }
    }
}