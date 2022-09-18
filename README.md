# DesafioManejoDeEventos
Desafio Manejo de eventos - Curso Desarrollo de videojuegos Coderhouse

>> Consigna:
Se pedirá que los alumnos entreguen una escena de Unity que tenga:
- Utilización de eventos para el manejo de al menos seis (6) situaciones distintas; 3 de
ellas deberán ser UnityEvents, y estar correctamente serializadas e implementadas en
un Prefab.
- Llamadas a debug logs de cada evento llamado, quién lo llamó, y quienes lo recibieron.

--------------------------------------------------------------------------------------------
Declaraciones de eventos:
>> C# Events:
- OnChangeHP, OnChangeScore, OnDead -> en script PlayerCollision
- OnDamage, OnHeal -> en script PlayerEvents
>> Unity Events:
- OnTriggerButton3D -> en script Button3D
- OnTriggerButtonZombie -> en script ButtonZombie
- OnTeleportation -> en script PlayerMove
