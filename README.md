
# EntryPoints

GraphQL-API: http://localhost:8080

SQL: http://localhost:1433

ElasticSearch: http://localhost:9200

Kibana: http://localhost:5601

# core-graphql
Simple implementation of GraphQl with net-core

RUN:
'docker-compose up'

Definición del Problema / Necesidades

Artistas precisan acceder a información de contacto y negocios de locales (bares, clubes de música, espacios culturales, etc..) con el objetivo de facilitar la programación y negociación de fechas.
Locales precisan gestionar la programación de fechas eliminando la carga administrativa y ambigüedad que implica la comunicación únicamente por emails.

Procesos

Artista
1 – Como Artista quiero poder buscar Locales filtrando por zona, estilos musicales, horarios disponibles, tipo de espacio, tipo de arreglo
2 – Como Artista quiero ver el calendario de un Local y subscribirme a cualquiera de las franjas horarias disponibles para mi
3 – Como Artista quiero poder charlar con el Local dentro del contexto de la subscripción pendiente a una franja horaria y ofrecer modificaciones al arreglo
4 – Como Artista quiero poder cargar y presentar de manera estéticamente adecuada mis datos en la aplicación: Nombre del Proyecto, Integrantes, Bio, Fotos, Videos, géneros, Datos de Contacto, Link a Website

Local
1 – Como Local quiero tener un calendario en el cual abrir franjas horarias disponibles para fechas con la opción de mostrar la franja solo a Artistas de ciertos géneros musicales
2 – Como Local quiero ver quienes solicitaron subscripción a cualquiera de mis franjas horarias y aceptar o declinar la subscripción
3 – Como Local quiero poder charlar con el Artista dentro del contexto de la subscripción a una franja horaria y ofrecer modificaciones al arreglo
4 - Como Local quiero poder confirmar o descartar el arreglo con un Artista para una franja horaria especifica
5 – Como local quiero poder invitar Artistas a ver mi calendario, algún día de mi calendario o a alguna franja horaria
6 – Como Local quiero poder cargar y presentar de manera estéticamente adecuada mis datos en la aplicación: Nombre del Local, Staff, Descripción, Fotos, Videos, Labels, Datos de Contacto, Link a Website

Entidades
Entidad	Descripción	Propiedades
		
		
		
		
		
		

Vistas
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		


Sistemas
Módulos
Dispositivos y Plataformas


Ejemplo GraphQl
{ 
 "query":
  "query{
     venues {
     	name,
		zone,
     	email
     },
     venue(id:1){
     	name,
     	contactName
     	email,
     	description,
     	technicalRider,
     	address,
     	notes
     },
     musicians {
    	name,
    	email,
    	zone
     },
	musician(id:2){
     	name,
     	email,
     	description,
     	address,
     	notes,
     	genres,
     	arrangement
     },
   }"
}


2- Ejemplo con Variables de VenueID
{ 
	"query":"query($venueId: Int!) { 
		venue(id: $venueId){ 
			name,
			contactName,
			email
		},
	}",
	"variables": "{
		venueId: 2
	}"
}