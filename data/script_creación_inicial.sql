/********* ESPECIFICACION DE LA BASE DE DATOS QUE SE VA A USAR *********/
USE GD2C2017

/********* SE CREA EL ESQUEMA *********/
IF (NOT EXISTS (select * from INFORMATION_SCHEMA.SCHEMATA where SCHEMA_NAME='GESDA'))
	BEGIN
		EXEC ('CREATE SCHEMA [GESDA] AUTHORIZATION [gd]');
		PRINT 'Esquema GESDA creado';
	END
/***************************************/
/********* CREACION DE TABLAS *********/
/***************************************/

CREATE TABLE GESDA.Funcion
(
 id_funcion Numeric(18,0) identity PRIMARY KEY,
 funcion_nombre Varchar(255)
)

CREATE TABLE GESDA.Rol
(
 id_rol Numeric(18,0) identity PRIMARY KEY,
 rol_nombre Varchar(255) NOT NULL,
 rol_estado Numeric(18,0)
)

CREATE TABLE GESDA.Rol_Funcion
(
 id_rol Numeric(18,0) REFERENCES GESDA.Rol,
 id_funcion Numeric(18,0) REFERENCES GESDA.Funcion
 PRIMARY KEY (id_rol,id_funcion)
)

CREATE TABLE GESDA.Usuario
(
 id_usuario Numeric(18,0) identity PRIMARY KEY,
 usuario_username Varchar(255) NOT NULL UNIQUE,
 usuario_password Varchar(255),
 usuario_intentos_login Numeric(18,0),
 usuario_estado Numeric(18,0) CHECK (usuario_estado IN (1,2))
)

CREATE TABLE GESDA.Rol_Usuario
(
 id_rol Numeric(18,0) REFERENCES GESDA.Rol,
 id_usuario Numeric(18,0) REFERENCES GESDA.Usuario
 PRIMARY KEY (id_rol,id_usuario)
)

CREATE TABLE GESDA.Sucursal
(
 id_sucursal Numeric(18,0) identity PRIMARY KEY,
 sucursal_nombre Varchar(255),
 sucursal_direccion Varchar(255),
 sucursal_codigo_postal Varchar(255),
 sucursal_estado Numeric(18,0) CHECK (sucursal_estado IN (1,2))
)

CREATE TABLE GESDA.Usuario_Sucursal
(
 id_usuario Numeric(18,0) REFERENCES GESDA.Usuario,
 id_sucursal Numeric(18,0) REFERENCES GESDA.Sucursal
 PRIMARY KEY (id_usuario,id_sucursal)
)

CREATE TABLE GESDA.Cliente
(
 id_cliente Numeric(18,0) identity PRIMARY KEY,
 cliente_nombre Varchar(255),
 cliente_apellido Varchar(255),
 cliente_dni Varchar(255),
 cliente_mail Varchar(255),
 cliente_telefono Numeric(18,0),
 cliente_direccion Varchar(255),
 cliente_codigo_postal Numeric(18,0),
 cliente_fecha_nacimiento Datetime,
 cliente_estado Numeric(18,0) CHECK (cliente_estado IN (1,2))
)

CREATE TABLE GESDA.Rubro
(
id_rubro Numeric(18,0) identity PRIMARY KEY,
rubro_descripcion Varchar(255),
)

CREATE TABLE GESDA.Empresa
(
 id_empresa Numeric(18,0) identity PRIMARY KEY,
 id_rubro Numeric(18,0) NULL REFERENCES GESDA.Rubro,
 empresa_nombre Varchar(255),
 empresa_cuit Varchar(255),
 empresa_direccion Varchar(255),
 empresa_estado Numeric(18,0) CHECK (empresa_estado IN (1,2))
)

CREATE TABLE GESDA.Factura
(
 id_factura Numeric(18,0) identity PRIMARY KEY,
 id_cliente Numeric(18,0) NULL REFERENCES GESDA.Cliente,
 id_empresa Numeric(18,0) NULL REFERENCES GESDA.Empresa,
 factura_numero Numeric(18,0),
 factura_fecha_alta Datetime,
 factura_fecha_vencimiento Datetime,
 factura_total Numeric(18,2),
 factura_estado Numeric(18,0) CHECK (factura_estado IN (1,2))
)

CREATE TABLE GESDA.Factura_Detalle
(
 id_factura_detalle Numeric(18,0) identity PRIMARY KEY,
 id_factura Numeric(18,0) NULL REFERENCES GESDA.Factura,
 factura_detalle_descripcion Varchar(255),
 factura_detalle_monto Numeric(18,2),
 factura_detalle_cantidad Numeric(18,0),
)

CREATE TABLE GESDA.Forma_Pago
(
 id_forma_pago Numeric(18,0) identity PRIMARY KEY,
 forma_pago_descripcion Varchar(255)
)

CREATE TABLE GESDA.Pago
(
 id_pago Numeric(18,0) identity PRIMARY KEY,
 id_sucursal Numeric(18,0) NULL REFERENCES GESDA.Sucursal,
 id_forma_pago Numeric(18,0) NULL REFERENCES GESDA.Forma_Pago,
 id_cliente Numeric(18,0) NULL REFERENCES GESDA.Cliente,
 pago_nro Numeric(18,0),
 pago_fecha Datetime,
 total Numeric(18,2)
)

CREATE TABLE GESDA.Pago_Detalle
(
 id_pago_detalle Numeric(18,0) identity PRIMARY KEY,
 id_pago Numeric(18,0) NULL REFERENCES GESDA.Pago,
 id_factura Numeric(18,0) NULL REFERENCES GESDA.Factura,
 itemPago_nro Numeric(18,0)
)

CREATE TABLE GESDA.Rendicion
(
 id_rendicion Numeric(18,0) identity PRIMARY KEY,
 id_empresa Numeric(18,0) NULL REFERENCES GESDA.Empresa,
 rendicion_nro Numeric(18,0),
 rendicion_fecha Datetime,
 rendicion_cantidad_facturas Numeric(18,0),
 rendicion_importe_neto Numeric(18,0),
 rendicion_comision Numeric(18,2),
 rendicion_importe_bruto Numeric(18,2)
)

CREATE TABLE GESDA.Rendicion_Detalle
(
 id_rendicion_detalle Numeric(18,0) identity PRIMARY KEY,
 id_rendicion Numeric(18,0) NULL REFERENCES GESDA.Rendicion,
 id_factura Numeric(18,0) NULL REFERENCES GESDA.Factura,
 itemRendicion_nro Numeric(18,0),
 itemRendicion_Importe Numeric(18,2)
)

CREATE TABLE GESDA.Devolucion
(
 id_devolucion Numeric(18,0) identity PRIMARY KEY,
 id_factura Numeric(18,0) NULL REFERENCES GESDA.Factura,
 motivo_devolucion Varchar(255)
)



/***************************************/
/********* CREACION DE INDICES *********/
/***************************************/

CREATE UNIQUE INDEX id_funcion ON GESDA.Funcion (id_funcion)
CREATE UNIQUE INDEX id_rol ON GESDA.Rol (id_rol)
CREATE UNIQUE INDEX id_rol_funcion ON GESDA.Rol_Funcion (id_rol,id_funcion)
CREATE UNIQUE INDEX id_usuario ON GESDA.Usuario (id_usuario)
CREATE UNIQUE INDEX id_rol_usuario ON GESDA.Rol_Usuario (id_rol,id_usuario)
CREATE UNIQUE INDEX id_sucursal ON GESDA.Sucursal (id_sucursal,sucursal_nombre,sucursal_direccion,sucursal_codigo_postal)
CREATE UNIQUE INDEX id_usuario_sucursal ON GESDA.Usuario_Sucursal (id_usuario,id_sucursal)
CREATE UNIQUE INDEX id_cliente ON GESDA.Cliente (id_cliente,cliente_dni,cliente_mail,cliente_nombre)
CREATE UNIQUE INDEX id_empresa ON GESDA.Empresa (id_empresa,empresa_nombre,empresa_cuit,id_rubro)
CREATE UNIQUE INDEX id_rubro ON GESDA.Rubro (id_rubro,rubro_descripcion)
CREATE UNIQUE INDEX id_factura ON GESDA.Factura (id_factura,id_cliente,id_empresa,factura_numero)
CREATE UNIQUE INDEX id_factura_detalle ON GESDA.Factura_Detalle (id_factura_detalle,id_factura)
CREATE UNIQUE INDEX id_pago ON GESDA.Pago (id_pago,id_sucursal,id_forma_pago,id_cliente,pago_nro)
CREATE UNIQUE INDEX id_forma_pago ON GESDA.Forma_Pago (id_forma_pago,forma_pago_descripcion)
CREATE UNIQUE INDEX id_pago_detalle ON GESDA.Pago_Detalle (id_pago_detalle,id_pago,id_factura)
CREATE UNIQUE INDEX id_rendicion ON GESDA.Rendicion (id_rendicion,id_empresa,rendicion_nro)
CREATE UNIQUE INDEX id_rendicion_detalle ON GESDA.Rendicion_Detalle (id_rendicion_detalle,id_rendicion,id_factura,itemRendicion_nro)

/***************************************/
/********* MIGRACION *********/
/***************************************/

--MIGRACION CLIENTE-----------------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO GESDA.Cliente (cliente_nombre,cliente_apellido,cliente_dni,cliente_mail,cliente_direccion,cliente_codigo_postal,cliente_fecha_nacimiento,cliente_estado)
	SELECT DISTINCT m.[Cliente-Nombre],m.[Cliente-Apellido],m.[Cliente-Dni],m.Cliente_Mail,m.Cliente_Direccion,m.Cliente_Codigo_Postal,m.[Cliente-Fecha_Nac],1
	FROM gd_esquema.Maestra m
--OBS: La columna cliente_telefono no existe en la tabla maestra
GO

--MIGRACION RUBRO------------------------------------------------------------------------------------------------------
set identity_insert gesda.rubro on;
INSERT INTO GESDA.Rubro(id_rubro,rubro_descripcion)
SELECT DISTINCT m.Empresa_Rubro,m.Rubro_Descripcion
FROM gd_esquema.Maestra m
set identity_insert gesda.rubro off;
GO

--MIGRACION EMPRESA------------------------------------------------------------------------------------------------------
INSERT INTO GESDA.Empresa (id_rubro,empresa_nombre,empresa_cuit,empresa_direccion,empresa_estado)
SELECT DISTINCT 1,m.Empresa_Nombre,m.Empresa_Cuit,m.Empresa_Direccion,1
FROM gd_esquema.Maestra m
GO

--MIGRACION SUCURSAL-----------------------------------------------------------------------------------------------------
INSERT INTO GESDA.Sucursal (sucursal_nombre,sucursal_direccion,sucursal_codigo_postal,sucursal_estado)
select distinct m.Sucursal_Nombre,m.Sucursal_Dirección,m.Sucursal_Codigo_Postal,1 FROM gd_esquema.Maestra m
where m.Sucursal_Nombre IS NOT NULL
GO

--MIGRACION FACTURA-----------------------------------------------------------------------------------------------------
INSERT INTO GESDA.Factura (id_cliente,id_empresa,factura_numero,factura_fecha_alta,factura_fecha_vencimiento,factura_total,factura_estado)
select distinct (select c.id_cliente from gesda.Cliente c where c.cliente_dni=m.[Cliente-Dni]) id_cliente,
(select id_empresa from gesda.empresa e where e.empresa_cuit=m.Empresa_Cuit) id_empresa,
m.Nro_Factura,m.Factura_Fecha,m.Factura_Fecha_Vencimiento,m.Factura_Total,1
FROM gd_esquema.Maestra m
GO

--MIGRACION FACTURA_DETALLE-----------------------------------------------------------------------------------------------------
INSERT INTO GESDA.Factura_Detalle (id_factura,factura_detalle_monto,factura_detalle_cantidad)
select distinct (select id_factura from gesda.Factura f where f.factura_numero=m.Nro_Factura) id_factura,m.ItemFactura_Monto,m.ItemFactura_Cantidad
FROM gd_esquema.Maestra m
GO

--MIGRACION FORMA_PAGO-----------------------------------------------------------------------------------------------------
INSERT INTO GESDA.Forma_Pago (forma_pago_descripcion)
select distinct m.FormaPagoDescripcion
FROM gd_esquema.Maestra m
where m.FormaPagoDescripcion is not null
GO

--MIGRACION PAGO-----------------------------------------------------------------------------------------------------
INSERT INTO GESDA.Pago (id_sucursal,id_forma_pago,id_cliente,pago_nro,pago_fecha,total)
select distinct (select id_sucursal from gesda.Sucursal s where s.sucursal_nombre=m.Sucursal_Nombre) id_sucursal,
(select id_forma_pago from gesda.forma_pago p where p.forma_pago_descripcion=m.FormaPagoDescripcion) id_forma_pago,
(select id_cliente from gesda.cliente c where c.cliente_dni=m.[Cliente-Dni]) id_cliente,
m.Pago_nro,m.Pago_Fecha,m.Total
FROM gd_esquema.Maestra m
where m.Pago_nro is not null
GO

--MIGRACION PAGO_DETALLE-----------------------------------------------------------------------------------------------------
INSERT INTO GESDA.Pago_Detalle (id_pago,id_factura,itemPago_nro)
select distinct (select id_pago from gesda.pago p where p.pago_nro=m.Pago_nro) id_pago,
(select id_factura from gesda.factura f where f.factura_numero=m.nro_factura) id_factura,
m.ItemPago_nro
FROM gd_esquema.Maestra m
where m.Pago_nro is not null
GO

--MIGRACION RENDICION-----------------------------------------------------------------------------------------------------
INSERT INTO GESDA.Rendicion (id_empresa,rendicion_nro,rendicion_fecha,rendicion_cantidad_facturas,rendicion_importe_neto,rendicion_comision,rendicion_importe_bruto)
select distinct (select id_empresa from gesda.empresa e where e.empresa_cuit=m.Empresa_Cuit) id_empresa,m.Rendicion_Nro,m.Rendicion_Fecha,
(select count(*) from (select distinct Rendicion_Nro,Nro_Factura from gd_esquema.Maestra ) tabla where tabla.Rendicion_Nro=m.Rendicion_Nro group by tabla.Rendicion_Nro) cantidad_facturas,
(select m1.Total-m1.ItemRendicion_Importe rendicion_importe_neto from gd_esquema.Maestra m1 where m1.Rendicion_Nro=m.Rendicion_Nro group by m1.Rendicion_Nro,m1.Total,m1.ItemRendicion_Importe) rendicion_importe_neto,convert(numeric(9,0),round((m.ItemRendicion_Importe*100)/m.Total,0)) rendicion_comision,
m.Total rendicion_importe_bruto
FROM gd_esquema.Maestra m
where m.Rendicion_Nro is not null
GO

--MIGRACION RENDICION_DETALLE-----------------------------------------------------------------------------------------------------
INSERT INTO GESDA.Rendicion_Detalle (id_rendicion,id_factura,itemRendicion_nro,itemRendicion_importe)
select distinct (select r.id_rendicion from gesda.Rendicion r where r.rendicion_nro=m.Rendicion_Nro) id_rendicion,
(select id_factura from gesda.factura f where f.factura_numero=m.Nro_Factura) id_factura,m.ItemRendicion_nro,m.ItemRendicion_Importe
FROM gd_esquema.Maestra m
where m.Rendicion_Nro is not null
GO

/***************************************/
/********* ABM ROL *********/
/***************************************/

create type GESDA.array_funciones as table (nombre varchar(255))
GO

create procedure GESDA.agregar_funciones (@nombre_rol varchar (255),@funciones gesda.array_funciones readonly,@resultado varchar(255) out)
as
	BEGIN TRY
		BEGIN TRANSACTION
		DECLARE @id_funcion numeric (18,0)
		Declare @id_rol int
		declare @funcion_nombre varchar(255)

		set @id_rol=(select id_rol from rol where rol_nombre=@nombre_rol)

		declare rol_funciones cursor for
		select f.nombre from @funciones f

		open rol_funciones
		fetch rol_funciones into @funcion_nombre

			WHILE (@@FETCH_STATUS = 0)
				BEGIN	
					set @id_funcion=(select id_funcion from GESDA.Funcion where funcion_nombre=@funcion_nombre)	
					insert into rol_funcion (id_rol,id_funcion) values (@id_rol,@id_funcion) --asocio rol y funcion
					fetch rol_funciones into @funcion_nombre
				END

		CLOSE rol_funciones
		DEALLOCATE rol_funciones

		set @resultado='se asociaron las funciones'
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION 
		set @resultado=ERROR_MESSAGE()
	END CATCH
go
create procedure GESDA.crear_rol (@nombre_rol varchar(255),@funciones array_funciones readonly,@resultado varchar(255) out)
as
	BEGIN TRY
		BEGIN TRANSACTION
			declare @funcion_nombre varchar(255)
			--verifico si existe el rol
			if(exists (select * from gesda.Rol r where r.rol_nombre=@nombre_rol))
				begin
					set @resultado='el nombre del rol ya existe, por favor seleccione otro'	
				end
			else
				begin
					insert into GESDA.Rol (rol_nombre,rol_estado) values (@nombre_rol,1)
					execute GESDA.agregar_funciones @nombre_rol,@funciones,@resultado out
					set @resultado='el rol se creo correctamente'	
				end
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION 	
		set @resultado='ERROR: '+@resultado+' + '+ERROR_MESSAGE()
	END CATCH
go
create procedure GESDA.modificar_funciones (@nombre_rol varchar (255),@funciones array_funciones readonly,@resultado varchar(255) out)
as
	BEGIN TRY
		BEGIN TRANSACTION
		DECLARE @id_funcion numeric (18,0)
		Declare @id_rol int
		declare @funcion_nombre varchar(255)

		set @id_rol=(select id_rol from rol where rol_nombre=@nombre_rol)

		--primero saco las funciones viejas
		declare funciones_viejas cursor for
		select f.funcion_nombre from gesda.Funcion f join gesda.Rol_Funcion rf on (f.id_funcion=rf.id_funcion) join gesda.Rol r on (r.id_rol=rf.id_rol) where r.id_rol=@id_rol

		open funciones_viejas
		fetch funciones_viejas into @funcion_nombre

		WHILE (@@FETCH_STATUS = 0)
			BEGIN	
				if( not exists(select f.nombre from @funciones f where f.nombre=@funcion_nombre ) )
					begin
						--lo desasocio
						set @id_funcion=(select id_funcion from GESDA.Funcion where funcion_nombre=@funcion_nombre)
						delete from GESDA.Rol_funcion where id_funcion=@id_funcion and id_rol=@id_rol
						set @resultado='se modificaron las funciones'
					end
				fetch funciones_viejas into @funcion_nombre
			END

		CLOSE funciones_viejas
		DEALLOCATE funciones_viejas

		--ahora agrego las funciones nuevas
		declare funciones_nuevas cursor for
		select f.nombre from @funciones f

		open funciones_nuevas
		fetch funciones_nuevas into @funcion_nombre

		WHILE (@@FETCH_STATUS = 0)
			BEGIN	
				if( not exists(select f.funcion_nombre from gesda.Funcion f join gesda.Rol_Funcion rf on (f.id_funcion=rf.id_funcion) join gesda.Rol r on (r.id_rol=rf.id_rol) where r.id_rol=@id_rol and f.funcion_nombre=@funcion_nombre ) )
					begin
						--lo agrego
						set @id_funcion=(select id_funcion from GESDA.Funcion where funcion_nombre=@funcion_nombre)
						insert into rol_funcion (id_rol,id_funcion) values (@id_rol,@id_funcion)

						set @resultado='se modificaron las funciones'
					end
				fetch funciones_nuevas into @funcion_nombre
			END

		CLOSE funciones_nuevas
		DEALLOCATE funciones_nuevas
				
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION 
		set @resultado=ERROR_MESSAGE()
	END CATCH
go
create procedure GESDA.modificar_rol_nombre (@nombre_viejo varchar(255),@nombre_nuevo varchar (255),@resultado varchar(255) out)
AS
	BEGIN TRY
		BEGIN TRANSACTION
	
			if(exists (select * from gesda.rol r where r.rol_nombre=@nombre_nuevo))
				begin
					set @resultado='ya existe ese nombre de rol, por favor elija otro'
				end
			else
				begin
					update GESDA.rol set rol_nombre=@nombre_nuevo
					where rol_nombre=@nombre_viejo 
					set @resultado='se modifico el nombre'
				end
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		set @resultado=ERROR_MESSAGE()
	END CATCH
go
create procedure GESDA.habilitar_rol (@nombre_rol varchar(255),@resultado varchar(255) out)
as
	BEGIN TRY
		BEGIN TRANSACTION
			update GESDA.ROL set rol_estado=1 where rol_nombre=@nombre_rol
			set @resultado='se habilito el rol correctamente'
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		set @resultado=ERROR_MESSAGE()
	END CATCH
go
create procedure GESDA.desasociar_rol_usuarios (@nombre_rol varchar(255),@resultado varchar(255) out)
AS
	BEGIN TRY
		BEGIN TRANSACTION
			Declare @error varchar(255)
			Declare @id_rol numeric (18,0)
			Declare @username varchar (255)

			set @id_rol=(select id_rol from GESDA.Rol where rol_nombre=@nombre_rol)
			delete from GESDA.Rol_Usuario where id_rol=@id_rol

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		set @resultado=ERROR_MESSAGE()
	END CATCH
go
create procedure GESDA.deshabilitar_rol (@nombre_rol varchar(255),@resultado varchar(255) out)
AS
	BEGIN TRY
		BEGIN TRANSACTION
			Declare @error varchar(255)
			update GESDA.ROL set rol_estado=2 where rol_nombre=@nombre_rol
			execute GESDA.desasociar_rol_usuarios @nombre_rol,@resultado out
			if(@resultado is null)
				begin
					set @resultado='se deshabilito el rol correctamente'
				end
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		set @resultado='ERROR: '+@resultado+' + '+ERROR_MESSAGE()
	END CATCH
go

		/***************************************/
/********* SE CREAN LAS FUNCIONALIDADES DE LOGUEO *********/
		/***************************************/

create procedure GESDA.login (@username varchar(255),@password varchar(255),@resultado varchar(255) out)
AS
	begin try
		begin transaction
			Declare @id_usuario numeric (18,0)
			Declare @cantidad_intentos varchar(255)

			set @id_usuario=(select id_usuario from GESDA.Usuario where usuario_username=@username)

			if(@id_usuario is null)
				begin
					set @resultado='usuario inexistente'
				end
			else
				begin
					set @cantidad_intentos=(select usuario_intentos_login from gesda.Usuario where id_usuario=@id_usuario)
					if (@cantidad_intentos>2)
						begin
							set @resultado='usuario bloqueado'
						end
					else
						begin

							if(exists (select * from gesda.Usuario where id_usuario=@id_usuario and usuario_password=HASHBYTES('SHA2_256',@password)))
								begin
									set @resultado='login correcto'
									update GESDA.usuario set usuario_intentos_login=0 where id_usuario=@id_usuario
								end
							else
								begin
									set @resultado='pass incorrecto'
									update GESDA.usuario set usuario_intentos_login=usuario_intentos_login+1 where id_usuario=@id_usuario
								end
						end
				end
		commit transaction
	end try
	begin catch
		rollback transaction
		set @resultado='se produjo un error en el procedure: '+ERROR_PROCEDURE()
	end catch
go


/***************************************/
/********* REGISTRO DE USUARIO*********/
/***************************************/
--Ejecutar el siguiente script para crear los usuarios admin y luis , que tienen roles administrador y cobrador

BEGIN

Declare @id_rol int
Declare @id_usuario int

insert into gesda.Rol values ('Administrador General',1)
insert into gesda.Rol values ('Cobrador',1)

insert into GESDA.Usuario values ('admin',HASHBYTES('SHA2_256', 'w23e'),0,1)
insert into GESDA.Usuario values ('luis',HASHBYTES('SHA2_256', 'luis'),0,1)

set @id_rol=(select id_rol from gesda.Rol r where r.rol_nombre ='Administrador General')
set @id_usuario=(select id_usuario from gesda.Usuario where usuario_username='admin')
insert into gesda.Rol_Usuario (id_rol,id_usuario) values (@id_rol,@id_usuario)

set @id_rol=(select id_rol from gesda.Rol where rol_nombre='Cobrador')
set @id_usuario=(select id_usuario from gesda.Usuario where usuario_username='admin')
insert into gesda.Rol_Usuario (id_rol,id_usuario) values (@id_rol,@id_usuario)

set @id_rol=(select id_rol from gesda.Rol where rol_nombre='Cobrador')
set @id_usuario=(select id_usuario from gesda.Usuario where usuario_username='luis')
insert into gesda.Rol_Usuario (id_rol,id_usuario) values (@id_rol,@id_usuario)

--creo las funciones y las asocio a un rol

insert into gesda.funcion values ('rol alta')
insert into gesda.funcion values ('rol modificacion')
insert into gesda.funcion values ('cliente alta')
insert into gesda.funcion values ('cliente modificacion')
insert into gesda.funcion values ('empresa alta')
insert into gesda.funcion values ('empresa modificacion')
insert into gesda.funcion values ('sucursal alta')
insert into gesda.funcion values ('sucursal modificacion')
insert into gesda.funcion values ('factura alta')
insert into gesda.funcion values ('factura modificacion')
insert into gesda.funcion values ('registrar pago')
insert into gesda.funcion values ('rendir facturas')
insert into gesda.funcion values ('devolucion')
insert into gesda.funcion values ('listado estadistico')

--Asocio al rol Adminitrador general todas las funciones
insert into gesda.rol_funcion values (1,1)
insert into gesda.rol_funcion values (1,2)
insert into gesda.rol_funcion values (1,3)
insert into gesda.rol_funcion values (1,4)
insert into gesda.rol_funcion values (1,5)
insert into gesda.rol_funcion values (1,6)
insert into gesda.rol_funcion values (1,7)
insert into gesda.rol_funcion values (1,8)
insert into gesda.rol_funcion values (1,9)
insert into gesda.rol_funcion values (1,10)
insert into gesda.rol_funcion values (1,11)
insert into gesda.rol_funcion values (1,12)
insert into gesda.rol_funcion values (1,13)
insert into gesda.rol_funcion values (1,14)

--Asocio al rol cobrador sus funciones
insert into gesda.rol_funcion values (2,3)
insert into gesda.rol_funcion values (2,4)
insert into gesda.rol_funcion values (2,5)
insert into gesda.rol_funcion values (2,6)
insert into gesda.rol_funcion values (2,9)
insert into gesda.rol_funcion values (2,10)
insert into gesda.rol_funcion values (2,11)
insert into gesda.rol_funcion values (2,13)

--Asocio los roles a las sucursales
insert into gesda.Usuario_Sucursal (id_usuario,id_sucursal) values (1,1)
insert into gesda.Usuario_Sucursal (id_usuario,id_sucursal) values (2,1)

END
GO


/***************************************/
/********* ABM CLIENTES*********/
/***************************************/

CREATE PROCEDURE [GESDA].[sp_alta_cliente] (@nombre nvarchar(255), @apellido nvarchar(255), @dni numeric(18,0), 
									@mail nvarchar(255), @telefono numeric(18,0), @direccion nvarchar(255),
									@codigoPostal nvarchar(255), @fec_nac datetime, @resultado varchar(255) out)
AS
BEGIN TRY
	
	SET NOCOUNT ON;

	BEGIN TRANSACTION
		IF 1 = (SELECT 1 FROM GESDA.Cliente where cliente_mail = @mail)
			begin
			set @resultado='mail existente'
			end
		ELSE
			begin
			INSERT INTO GESDA.Cliente(cliente_nombre, cliente_apellido, cliente_dni, cliente_mail,
										cliente_telefono, cliente_direccion, cliente_codigo_postal,
										cliente_fecha_nacimiento, cliente_estado)
			VALUES (@nombre, @apellido, @dni, @mail, @telefono, @direccion, @codigoPostal, @fec_nac, 1)
			set @resultado='Se dio de alta correctamente'
			end
	COMMIT TRANSACTION
END TRY

BEGIN CATCH
		rollback transaction
		set @resultado='se produjo un error en el procedure: '+ERROR_PROCEDURE()
END CATCH
GO
CREATE PROCEDURE [GESDA].[modificar_cliente_nombre] (@cliente_nombre_nuevo varchar(255), @cliente_dni numeric(18,0), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Cliente
		SET cliente_nombre = @cliente_nombre_nuevo
		WHERE cliente_dni = @cliente_dni

		SET @resultado = 'Se modifico el nombre correctamente'
	COMMIT TRANSACTION
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()	
END CATCH
GO
CREATE PROCEDURE [GESDA].[modificar_cliente_apellido](@cliente_apellido_nuevo varchar(255), @cliente_dni numeric(18,0), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Cliente
		SET cliente_apellido = @cliente_apellido_nuevo
		WHERE cliente_dni = @cliente_dni
		SET @resultado = 'Se modifico el apellido correctamente'  
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO
CREATE PROCEDURE [GESDA].[modificar_cliente_dni](@cliente_dni_nuevo numeric(18,0), @cliente_dni numeric(18,0), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Cliente
		SET cliente_dni = @cliente_dni_nuevo
		WHERE cliente_dni = @cliente_dni
		SET @resultado = 'Se modifico el DNI correctamente'  
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO
CREATE PROCEDURE [GESDA].[modificar_cliente_mail](@cliente_mail_nuevo varchar(255), @cliente_dni numeric(18,0), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Cliente
		SET cliente_mail = @cliente_mail_nuevo
		WHERE cliente_dni = @cliente_dni
		SET @resultado = 'Se modifico el e-mail correctamente'  
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO
CREATE PROCEDURE [GESDA].[modificar_cliente_telefono](@cliente_telefono_nuevo numeric(18,0), @cliente_dni numeric(18,0), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Cliente
		SET cliente_telefono = @cliente_telefono_nuevo
		WHERE cliente_dni = @cliente_dni
		SET @resultado = 'Se modifico el telefono correctamente'  
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO
CREATE PROCEDURE [GESDA].[modificar_cliente_direccion](@cliente_direccion_nuevo varchar(255), @cliente_dni numeric(18,0), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Cliente
		SET cliente_direccion = @cliente_direccion_nuevo
		WHERE cliente_dni = @cliente_dni
		SET @resultado = 'Se modifico la direccion correctamente'  
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO
CREATE PROCEDURE [GESDA].[modificar_cliente_codigo_postal](@cliente_codigo_postal_nuevo varchar(255), @cliente_dni numeric(18,0), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Cliente
		SET cliente_codigo_postal = @cliente_codigo_postal_nuevo
		WHERE cliente_dni = @cliente_dni
		SET @resultado = 'Se modifico el codigo postal correctamente'  
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO
CREATE PROCEDURE [GESDA].[modificar_cliente_fecha_nac](@cliente_fecha_nac_nuevo datetime, @cliente_dni numeric(18,0), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Cliente
		SET cliente_fecha_nacimiento = @cliente_fecha_nac_nuevo
		WHERE cliente_dni = @cliente_dni
		SET @resultado = 'Se modifico la fecha de nacimiento correctamente'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH	
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO
CREATE PROCEDURE [GESDA].[deshabilitar_cliente](@cliente_dni numeric(18,0), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Cliente
		SET cliente_estado = 2		
		WHERE cliente_dni = @cliente_dni
		SET @resultado = 'Se deshabilito el cliente'  
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO
CREATE PROCEDURE [GESDA].[habilitar_cliente](@cliente_dni numeric(18,0), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Cliente
		SET cliente_estado = 1		
		WHERE cliente_dni = @cliente_dni
		SET @resultado = 'Se habilito el cliente'  
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO



/***************************************/
/********* ABM EMPRESA*********/
/***************************************/
CREATE PROCEDURE [GESDA].[alta_empresa] (@nombre nvarchar(255), @cuit nvarchar(50), @direccion nvarchar(255), @nombreRubro nvarchar(255), @resultado varchar(255) out)
AS
BEGIN TRY
	BEGIN TRANSACTION
		DECLARE @id_rubro numeric(18,0) 
		select @id_rubro = id_rubro from GESDA.rubro where rubro_descripcion = @nombreRubro
		
		PRINT @id_rubro

		IF 1 = (SELECT 1 FROM GESDA.empresa where empresa_cuit = @cuit)
			begin
			set @resultado='el numero de cuit ya existe, por favor seleccione otro'
			end
		ELSE
			begin
			INSERT INTO GESDA.Empresa(empresa_nombre, empresa_cuit, empresa_direccion, id_rubro, empresa_estado)
			VALUES (@nombre, @cuit, @direccion, @id_rubro,1)
			set @resultado='alta de empresa exitosa'
			end
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
		rollback transaction
		set @resultado= ERROR_MESSAGE()	
END CATCH
GO

CREATE PROCEDURE [GESDA].[modificar_empresa_nombre] (@empresa_nombre_nuevo varchar(255), @empresa_cuit nvarchar(255), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Empresa
		SET empresa_nombre = @empresa_nombre_nuevo
		WHERE empresa_cuit = @empresa_cuit

		SET @resultado = 'Se modifico el nombre de empresa correctamente'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()	
END CATCH
GO

CREATE PROCEDURE [GESDA].[modificar_empresa_cuit](@empresa_cuit_nuevo nvarchar(255), @empresa_cuit nvarchar(255), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		IF (exists (SELECT * FROM GESDA.empresa where empresa_cuit = @empresa_cuit_nuevo))
			begin
			set @resultado='No se pudo actualizar Cuit.El Cuit informado se encuentra asociado a una entidad ya existente'
			end
		ELSE	
			BEGIN
			UPDATE GESDA.Empresa
			SET empresa_cuit = @empresa_cuit_nuevo
			WHERE empresa_cuit = @empresa_cuit
			SET @resultado = 'Se actualizo cuit correctamente'  
			END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [GESDA].[modificar_empresa_direccion](@empresa_direccion_nuevo nvarchar(255), @empresa_cuit nvarchar(50), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Empresa
		SET empresa_direccion = @empresa_direccion_nuevo
		WHERE empresa_cuit = @empresa_cuit
		SET @resultado = 'Se actualizo la direccion correctamente'  
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [GESDA].[modificar_empresa_rubro] (@empresa_rubro_nuevo varchar(255), @empresa_cuit nvarchar(50), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		DECLARE @id_rubro numeric(18,0) 
		select @id_rubro = id_rubro from GESDA.rubro where rubro_descripcion = @empresa_rubro_nuevo
		
		UPDATE GESDA.Empresa
		SET id_rubro = @id_rubro
		WHERE empresa_cuit = @empresa_cuit

		SET @resultado = 'Se actualizo el rubro correctamente'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()	
END CATCH
GO

CREATE PROCEDURE [GESDA].[obtenerCuitEmpresa] (@empresa_cuit varchar(50), @cuitTipoGlobal varchar(2) out
, @cuitNumero varchar(8) out, @cuitDigitoVerif varchar(1) out)
AS
BEGIN
			SELECT @cuitTipoGlobal = SUBSTRING(empresa_cuit,1,CHARINDEX('-',empresa_cuit)-1),
			@cuitNumero = SUBSTRING(empresa_cuit, CHARINDEX('-',empresa_cuit)+1, CHARINDEX('-', empresa_cuit, CHARINDEX('-',empresa_cuit)+1)-3),
			@cuitDigitoVerif = SUBSTRING(empresa_cuit, CHARINDEX('-', empresa_cuit, CHARINDEX('-',empresa_cuit)+1)+1,1)
			from GESDA.Empresa
			where empresa_cuit = @empresa_cuit
END
GO

CREATE PROCEDURE [GESDA].[deshabilitar_empresa](@empresa_cuit nvarchar(50), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		DECLARE @id_empresa numeric(18,0)
		SELECT @id_empresa = id_empresa from GESDA.Empresa where empresa_cuit = @empresa_cuit
		
		/*Actualizo si no hay rendiciones pendientes*/
		IF 1 = (select max (1) from GESDA.Factura a left join GESDA.Rendicion_Detalle b 
				on a.id_factura = b.id_factura 
				where id_empresa = @id_empresa and id_rendicion is null)
			BEGIN
				set @resultado='No se puede deshabilitar empresa ya que hay rendiciones pendientes'
			END
		ELSE
			BEGIN
				UPDATE GESDA.Empresa
				SET empresa_estado = 2		
				WHERE empresa_cuit = @empresa_cuit
				SET @resultado = 'Se deshabilito empresa correctamente'  
			END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO

CREATE PROCEDURE [GESDA].[habilitar_empresa](@empresa_cuit nvarchar(50), @resultado varchar(255) output)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Empresa
		SET empresa_estado = 1		
		WHERE empresa_cuit = @empresa_cuit
		SET @resultado = 'Se habilito empresa correctamente'  
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado = ERROR_MESSAGE()
END CATCH
GO

/***************************************/
/********* REGISTRO PAGO FACTURAS*********/
/***************************************/

CREATE PROCEDURE GESDA.verificarCliente (@cliente_dni varchar(255),@resultado varchar(255) out) AS
BEGIN TRY
	DECLARE @id_cliente Numeric(18,0)
	SET @id_cliente = (SELECT id_cliente FROM GESDA.Cliente WHERE @cliente_dni=cliente_dni)
	IF(@id_cliente is not null)
		BEGIN
			IF((SELECT cliente_estado FROM GESDA.Cliente WHERE @id_cliente=id_cliente)=1)
				BEGIN
					set @resultado='El Cliente está habilitado'
				END
			ELSE
				BEGIN
					set @resultado='El Cliente está inhabilitado'
				END
		END
	ELSE
		BEGIN
			set @resultado = 'El cliente no existe'
		END
END TRY
	BEGIN CATCH
			rollback transaction
			set @resultado='se produjo un error en el procedure: '+ERROR_PROCEDURE()
	END CATCH
GO
CREATE PROCEDURE GESDA.verificarFacturaAPagar (@factura_numero Numeric(18,0),@empresa_nombre Varchar(255), @fecha_actual datetime,@resultado Varchar(255) out) AS
	BEGIN TRY
		BEGIN TRANSACTION
			DECLARE @id_factura Numeric(18,0)
			DECLARE @id_empresa Numeric(18,0)
			SET @id_empresa = (SELECT id_empresa FROM GESDA.Empresa WHERE @empresa_nombre=empresa_nombre)
			SET @id_factura = (SELECT id_factura FROM GESDA.Factura WHERE @factura_numero=factura_numero AND @id_empresa=id_empresa)
			IF(@id_factura is not null)
					BEGIN
						IF((SELECT factura_estado FROM GESDA.factura WHERE @id_factura=id_factura)=1)
							BEGIN
								IF((SELECT factura_fecha_vencimiento FROM Factura WHERE @id_factura=id_factura)>=@fecha_actual)
									BEGIN
										IF((SELECT factura_total FROM Factura WHERE @id_factura=id_factura)>0)
											BEGIN
												IF((SELECT empresa_estado FROM GESDA.Empresa WHERE @id_empresa=id_empresa)=1)
													BEGIN
														IF(NOT EXISTS(SELECT * FROM GESDA.Pago_Detalle WHERE @id_factura=id_factura))
															BEGIN
																SET @resultado='La factura se puede pagar'
															END
														ELSE
															BEGIN
																IF(EXISTS(SELECT * FROM GESDA.Devolucion WHERE @id_factura=id_factura))
																	BEGIN
																		SET @resultado='La factura se puede pagar'
																	END
																ELSE
																	BEGIN
																		SET @resultado='La factura ya esta paga'
																	END
															END
													END
												ELSE
													BEGIN
														SET @resultado = 'Empresa inhabilitada'
													END
											END
										ELSE
											BEGIN
												SET @resultado= 'El importe de la factura es 0 o menor'
											END
									END
								ELSE
									BEGIN
										set @resultado = 'La factura ya venció'
									END
							END
						ELSE
							BEGIN
								set @resultado = 'La factura esta inhabilitada'
							END
					END
			ELSE
				BEGIN
					set @resultado = 'La factura no existe'
				END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION 
		SET @resultado= 'se produjo un error en el procedure: '+ERROR_PROCEDURE()		
	END CATCH
GO
CREATE PROCEDURE GESDA.CrearPago (@sucursal_nombre varchar(255),@forma_pago_descripcion Varchar(255), @cliente_dni Varchar(255), @pago_fecha Datetime, @total Numeric(18,2), @resultado varchar(255) OUT) AS
	BEGIN TRY
		DECLARE @id_sucursal Numeric(18,0)
		SET @id_sucursal=(SELECT id_sucursal FROM GESDA.Sucursal WHERE sucursal_nombre=@sucursal_nombre)
		DECLARE @id_forma_pago Numeric(18,0)
		SET @id_forma_pago=(SELECT id_forma_pago FROM GESDA.Forma_Pago WHERE forma_pago_descripcion=@forma_pago_descripcion)
		DECLARE @id_cliente Numeric(18,0)
		SET @id_cliente=(SELECT id_cliente FROM GESDA.Cliente WHERE cliente_dni=@cliente_dni)

		INSERT INTO GESDA.Pago(id_sucursal,id_forma_pago,id_cliente,pago_fecha,total)
		VALUES (@id_sucursal,@id_forma_pago,@id_cliente,@pago_fecha,@total)
		SET @resultado='El Pago se registro correctamente'
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION 
		set @resultado= 'se produjo un error en el procedure: '+ERROR_PROCEDURE()		
	END CATCH
GO 
CREATE PROCEDURE GESDA.InsertarItemPago (@id_pago Numeric(18,0),@factura_numero Numeric(18,0),@empresa_nombre Varchar(255),@resultado varchar(255) out) AS
	BEGIN TRY
		DECLARE @id_empresa Numeric(18,0)
		SET @id_empresa=(SELECT id_empresa FROM GESDA.Empresa WHERE @empresa_nombre=empresa_nombre)
		DECLARE @id_factura Numeric(18,0)
		SET @id_factura = (SELECT id_factura FROM GESDA.Factura WHERE @factura_numero=factura_numero AND @id_empresa=id_empresa)
		INSERT INTO GESDA.Pago_Detalle (id_pago,id_factura)
		VALUES (@id_pago,@id_factura)

		IF(EXISTS (SELECT * FROM gesda.Devolucion WHERE id_factura=@id_factura))
			BEGIN
				UPDATE gesda.devolucion SET id_factura=null WHERE id_factura=@id_factura
			END
		set @resultado= null
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION 
		SET @resultado= 'se produjo un error en el procedure: '+ERROR_PROCEDURE()		
	END CATCH
GO
/***************************************/
/********* RENDICION FACTURAS COBRADAS*********/
/***************************************/
CREATE PROCEDURE GESDA.verificarEmpresa (@empresa_nombre Varchar(255),@fecha_actual DateTime, @resultado varchar(255) out) AS
	BEGIN TRY
		DECLARE @id_empresa Numeric(18,0)
			SET @id_empresa=(SELECT id_empresa FROM GESDA.Empresa WHERE empresa_nombre=@empresa_nombre)
			BEGIN TRANSACTION
			IF(@id_empresa is not null)
				BEGIN
					IF((SELECT empresa_estado FROM GESDA.Empresa WHERE @id_empresa=id_empresa)=1)
						BEGIN
							--te deja rendir si ese mes y año no hubo ya una rendicion
							IF(NOT EXISTS(SELECT * from gesda.Rendicion WHERE month(rendicion_fecha)=month(@fecha_actual) AND year(rendicion_fecha)=year(@fecha_actual) AND @id_empresa=id_empresa))
								BEGIN
									SET @resultado ='Empresa verificada correctamente'
								END
							ELSE
								BEGIN
									SET @resultado ='La empresa ya rindió este mes'
								END
						END
					ELSE
						BEGIN
							SET @resultado ='Empresa inhabilitada'
						END
				END
			ELSE
				BEGIN
					SET @resultado ='La empresa no existe'
				END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
			rollback transaction
			set @resultado='se produjo un error en el procedure: '+ERROR_PROCEDURE()
	END CATCH
GO
CREATE PROCEDURE GESDA.crearRendicion(@empresa_nombre Varchar(255), @rendicion_fecha Datetime, @rendicion_cantidad_facturas Numeric(18,0), 
@rendicion_importe_neto Numeric(18,0), @rendicion_comision Numeric(18,2), @rendicion_importe_bruto Numeric(18,2), @resultado varchar(255)OUT) AS
	BEGIN TRY
		DECLARE @id_empresa Numeric(18,0)
		SET @id_empresa=(SELECT id_empresa FROM GESDA.Empresa WHERE empresa_nombre=@empresa_nombre)
		BEGIN TRANSACTION
			INSERT INTO GESDA.Rendicion (id_empresa, rendicion_fecha, rendicion_cantidad_facturas, rendicion_importe_neto, rendicion_comision, rendicion_importe_bruto)
			VALUES (@id_empresa, @rendicion_fecha, @rendicion_cantidad_facturas, @rendicion_importe_neto, @rendicion_comision, @rendicion_importe_bruto)
			set @resultado = 'Se creó la rendición correctamente'
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
			rollback transaction
			set @resultado='se produjo un error en el procedure: '+ERROR_PROCEDURE()
	END CATCH
GO
CREATE PROCEDURE GESDA.insertarItemRendicion(@id_rendicion Numeric(18,0), @factura_numero Numeric(18,0), @empresa_nombre varchar(255), @resultado varchar(255) OUT) AS
begin
	BEGIN TRY 
		BEGIN TRANSACTION
		DECLARE @id_empresa Numeric(18,0)
		SET @id_empresa = (SELECT id_empresa FROM gesda.empresa WHERE @empresa_nombre = empresa_nombre)
		DECLARE @id_factura Numeric(18,0)
		SET @id_factura = (SELECT id_factura FROM GESDA.factura WHERE @factura_numero = factura_numero AND @id_empresa = id_empresa)
			INSERT INTO GESDA.rendicion_detalle(id_rendicion,id_factura)
			VALUES(@id_rendicion,@id_factura)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
			rollback transaction
			set @resultado='se produjo un error en el procedure: '+ERROR_PROCEDURE()
	END CATCH
end
GO
/***************************************/
/********* DEVOLUCIONES*********/
/***************************************/
create procedure GESDA.devolver_factura (@factura_numero numeric(18,0),@empresa_cuit varchar (255),@motivo_devolucion varchar (255),@resultado varchar(255) out)
as
	BEGIN TRY
		BEGIN TRANSACTION
		DECLARE @id_factura numeric (18,0)
		Declare @id_empresa numeric (18,0)

		set @id_empresa=(select id_empresa from gesda.Empresa e where e.empresa_cuit=@empresa_cuit)
		set @id_factura=(select id_factura from gesda.Factura f where f.factura_numero=@factura_numero and f.id_empresa=@id_empresa)

		--verifico si la factura fue devuelta anteriormente
		if(exists (select * from gesda.devolucion d where d.id_factura=@id_factura))
			begin
				update gesda.Devolucion set motivo_devolucion=@motivo_devolucion where id_factura=@id_factura
			end
		else
			begin
				insert into gesda.Devolucion (id_factura,motivo_devolucion) values (@id_factura,@motivo_devolucion)			
			end

		set @resultado='se devolvio la factura'

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION 
		set @resultado=ERROR_MESSAGE()
	END CATCH
go

/***************************************/
/********* LISTADO ESTADISTICO*********/
/***************************************/

CREATE FUNCTION GESDA.ClientesConMasPagos(@trimestre varchar(100), @anio varchar(4)) 
RETURNS @resultado TABLE
(
	cliente_nombre varchar(255),
	cliente_apellido varchar(255),
	cliente_dni numeric(18,0),
	cantidad_pagos numeric(18,0)
)
AS
	BEGIN
		DECLARE @inicio_trimestre DATE
		DECLARE @fin_trimestre DATE

		SET @inicio_trimestre = case
		  when @trimestre='Primer trimestre' then CONVERT(datetime,@anio+'-01-01 00:00:00',120)
		  when @trimestre='Segundo trimestre' then CONVERT(datetime,@anio+'-04-01 00:00:00',120)
		  when @trimestre='Tercer trimestre' then CONVERT(datetime,@anio+'-07-01 00:00:00',120)
		  when @trimestre='Cuarto trimestre' then CONVERT(datetime,@anio+'-10-01 00:00:00',120)
		END
		SET @fin_trimestre = CASE
		  when @trimestre='Primer trimestre' then CONVERT(datetime,@anio+'-03-31 23:59:59',120)
		  when @trimestre='Segundo trimestre' then CONVERT(datetime,@anio+'-06-30 23:59:59',120)
		  when @trimestre='Tercer trimestre' then CONVERT(datetime,@anio+'-09-30 23:59:59',120)
		  when @trimestre='Cuarto trimestre' then CONVERT(datetime,@anio+'-12-31 23:59:59',120)
		END 

		insert into @resultado
		SELECT TOP 5 c.cliente_nombre,c.cliente_apellido,c.cliente_dni,count(*) cantidad_pagos
		from gesda.Cliente c
		join gesda.Pago p on (p.id_cliente=c.id_cliente)
		where p.pago_fecha BETWEEN @inicio_trimestre AND @fin_trimestre
		group by c.cliente_nombre,c.cliente_apellido,c.cliente_dni
		order by cantidad_pagos desc

		RETURN
	END
GO
CREATE FUNCTION GESDA.PorcentajeFacturas(@trimestre varchar(100), @anio varchar(4)) 
RETURNS @resultado TABLE
(
	empresa_nombre varchar(255),
	porcentaje_facturas Numeric(18,2),
	cantidad_facturas Numeric(18,0),
	total_cobrado Numeric(18,0)
)
AS
	BEGIN
		DECLARE @inicio_trimestre DATE
		DECLARE @fin_trimestre DATE

		SET @inicio_trimestre = case
		  when @trimestre='Primer trimestre' then CONVERT(datetime,@anio+'-01-01 00:00:00',120)
		  when @trimestre='Segundo trimestre' then CONVERT(datetime,@anio+'-04-01 00:00:00',120)
		  when @trimestre='Tercer trimestre' then CONVERT(datetime,@anio+'-07-01 00:00:00',120)
		  when @trimestre='Cuarto trimestre' then CONVERT(datetime,@anio+'-10-01 00:00:00',120)
		END
		SET @fin_trimestre = CASE
		  when @trimestre='Primer trimestre' then CONVERT(datetime,@anio+'-03-31 23:59:59',120)
		  when @trimestre='Segundo trimestre' then CONVERT(datetime,@anio+'-06-30 23:59:59',120)
		  when @trimestre='Tercer trimestre' then CONVERT(datetime,@anio+'-09-30 23:59:59',120)
		  when @trimestre='Cuarto trimestre' then CONVERT(datetime,@anio+'-12-31 23:59:59',120)
		END 
		--no tuve en cuenta devoluciones no se si es necesario
		insert into @resultado
		SELECT TOP 5 empresa_nombre ,
		(COUNT(pd.id_factura)*100/(SELECT COUNT (*) FROM GESDA.Pago_Detalle pd join gesda.pago p on (pd.id_pago=p.id_pago) WHERE p.pago_fecha BETWEEN @inicio_trimestre AND @fin_trimestre)) AS 'Porcentaje de facturas cobradas',
		 COUNT(pd.id_factura) AS 'Total de facturas' , SUM(factura_total) AS 'Total cobrado'
		FROM GESDA.Factura F JOIN GESDA.Empresa E ON (F.id_empresa=E.id_empresa)
		JOIN GESDA.Pago_Detalle Pd ON (F.id_factura=Pd.id_Factura)
		JOIN GESDA.Pago P ON (Pd.id_pago=P.id_pago)
		WHERE p.pago_fecha BETWEEN @inicio_trimestre AND @fin_trimestre
		GROUP BY empresa_nombre
		ORDER BY 'Porcentaje de facturas cobradas' DESC
		
		RETURN
	END
GO
CREATE FUNCTION GESDA.EmpresasMayorMonto(@trimestre varchar(100), @anio varchar(4)) 
RETURNS @resultado TABLE
(
		empresa_nombre varchar(255),
		monto_rendido Numeric(18,0),
		monto_bruto Numeric(18,0),
		total_facturas Numeric(18,0)
)
AS
	BEGIN
		DECLARE @inicio_trimestre DATE
		DECLARE @fin_trimestre DATE

		SET @inicio_trimestre = case
		  when @trimestre='Primer trimestre' then CONVERT(datetime,@anio+'-01-01 00:00:00',120)
		  when @trimestre='Segundo trimestre' then CONVERT(datetime,@anio+'-04-01 00:00:00',120)
		  when @trimestre='Tercer trimestre' then CONVERT(datetime,@anio+'-07-01 00:00:00',120)
		  when @trimestre='Cuarto trimestre' then CONVERT(datetime,@anio+'-10-01 00:00:00',120)
		END
		SET @fin_trimestre = CASE
		  when @trimestre='Primer trimestre' then CONVERT(datetime,@anio+'-03-31 23:59:59',120)
		  when @trimestre='Segundo trimestre' then CONVERT(datetime,@anio+'-06-30 23:59:59',120)
		  when @trimestre='Tercer trimestre' then CONVERT(datetime,@anio+'-09-30 23:59:59',120)
		  when @trimestre='Cuarto trimestre' then CONVERT(datetime,@anio+'-12-31 23:59:59',120)
		END 
		
		insert into @resultado
		SELECT TOP 5 empresa_nombre, SUM(rendicion_importe_neto) AS 'Monto rendido', SUM(rendicion_importe_bruto) AS 'Monto rendido en bruto', SUM(rendicion_cantidad_facturas) AS 'Cantidad total de facturas'
		FROM GESDA.Empresa E JOIN GESDA.Rendicion R ON (e.id_empresa=r.id_empresa)
		WHERE rendicion_fecha BETWEEN @inicio_trimestre AND @fin_trimestre
		GROUP BY empresa_nombre
		ORDER BY 'Monto rendido' DESC

		RETURN
	END
GO
CREATE FUNCTION GESDA.Clientescumplidores(@trimestre varchar(100), @anio varchar(4)) 
RETURNS @resultado TABLE
(
	cliente varchar(255),
	porcentaje_facturas Numeric(18,2),
	cant_facturas Numeric(18,0),
	cant_facturas_pagadas Numeric(18,0)
)
AS
	BEGIN
		DECLARE @inicio_trimestre DATE
		DECLARE @fin_trimestre DATE

		SET @inicio_trimestre = case
		  when @trimestre='Primer trimestre' then CONVERT(datetime,@anio+'-01-01 00:00:00',120)
		  when @trimestre='Segundo trimestre' then CONVERT(datetime,@anio+'-04-01 00:00:00',120)
		  when @trimestre='Tercer trimestre' then CONVERT(datetime,@anio+'-07-01 00:00:00',120)
		  when @trimestre='Cuarto trimestre' then CONVERT(datetime,@anio+'-10-01 00:00:00',120)
		END
		SET @fin_trimestre = CASE
		  when @trimestre='Primer trimestre' then CONVERT(datetime,@anio+'-03-31 23:59:59',120)
		  when @trimestre='Segundo trimestre' then CONVERT(datetime,@anio+'-06-30 23:59:59',120)
		  when @trimestre='Tercer trimestre' then CONVERT(datetime,@anio+'-09-30 23:59:59',120)
		  when @trimestre='Cuarto trimestre' then CONVERT(datetime,@anio+'-12-31 23:59:59',120)
		END 
		
		insert into @resultado
		SELECT TOP 5 cliente_apellido+' '+cliente_nombre AS 'Cliente', COUNT(pd.id_factura)*100/cant_facturas AS 'Porcentaje de facturas pagadas', cant_facturas AS 'Cantidad de facturas', COUNT(pd.id_factura) AS 'Cantidad de facturas pagadas'
		FROM GESDA.Cliente C JOIN Gesda.Factura F ON (C.id_cliente=f.id_cliente)
		JOIN gesda.Pago_Detalle Pd ON (pd.id_factura=f.id_factura)
		JOIN (SELECT c.id_cliente, COUNT(id_factura) as cant_facturas from gesda.cliente c JOIN gesda.factura f on (c.id_cliente=f.id_cliente) WHERE factura_fecha_alta BETWEEN @inicio_trimestre AND @fin_trimestre group by c.id_cliente) AS Q ON (c.id_cliente=q.id_cliente)
		WHERE factura_fecha_alta BETWEEN @inicio_trimestre AND @fin_trimestre
		GROUP BY cliente_apellido+' '+cliente_nombre,cant_facturas
		ORDER BY 'Porcentaje de facturas pagadas'desc,cant_facturas desc

		RETURN
	END
GO

/***************************************/
/********* ABM SUCURSAL *********/
/***************************************/

--PROCEDURE ALTA SUCURSAL
CREATE PROCEDURE GESDA.alta_sucursal (@nombre Varchar(255), @direccion Varchar(255), @codigoPostal Varchar(255), @resultado Varchar(255) out)
AS
BEGIN TRY
	BEGIN TRANSACTION
		IF (NOT EXISTS (SELECT * FROM GESDA.sucursal WHERE sucursal_codigo_postal=@codigoPostal))
			BEGIN
				INSERT INTO GESDA.Sucursal(sucursal_nombre, sucursal_direccion, sucursal_codigo_postal,sucursal_estado)
				VALUES (@nombre,@direccion,@codigoPostal,1)
				SET @resultado='Se creo la sucursal correctamente'
			END
		ELSE
			BEGIN
				SET @resultado='error: ya existe una sucursal con ese codigo postal'
			END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='Se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

--PROCEDURE DESHABILITAR UNA SUCURSAL
CREATE PROCEDURE GESDA.deshabilitar_sucursal (@codigo_postal Varchar(255), @resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		DECLARE @idSucursal Numeric(18,0)
		SET @idSucursal = (SELECT id_sucursal FROM GESDA.Sucursal WHERE sucursal_codigo_postal = @codigo_postal)
		--deshabilito la sucursal
		UPDATE GESDA.Sucursal
		SET sucursal_estado = 2
		WHERE sucursal_codigo_postal = @codigo_postal
		--deshabilito a los usuarios de la sucursal
		UPDATE GESDA.Usuario
		SET usuario_estado = 2
		WHERE id_usuario IN (SELECT id_usuario FROM GESDA.Usuario_Sucursal WHERE id_sucursal = @idSucursal)
		SET @resultado='La sucursal SE DESHABILITO correctamente'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='Se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

--HABILITAR Sucursal
CREATE PROCEDURE GESDA.habilitar_sucursal (@codigo_postal Varchar(255), @resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		DECLARE @idSucursal Numeric(18,0)
		SET @idSucursal = (SELECT id_sucursal FROM GESDA.Sucursal WHERE sucursal_codigo_postal = @codigo_postal)
		--habilito la sucursal
		UPDATE GESDA.Sucursal
		SET sucursal_estado = 1
		WHERE sucursal_codigo_postal = @codigo_postal
		--habilito a los usuarios de la sucursal
		UPDATE GESDA.Usuario
		SET usuario_estado = 1
		WHERE id_usuario IN (SELECT id_usuario FROM GESDA.Usuario_Sucursal WHERE id_sucursal=@idSucursal)
		SET @resultado='La sucursal se habilito'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='Se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

--Modificar nombre sucursal
CREATE PROCEDURE GESDA.modificar_nombre_sucursal (@codigo_postal Varchar(255), @nombre_nuevo Varchar(255), @resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Sucursal
		SET sucursal_nombre = @nombre_nuevo
		WHERE sucursal_codigo_postal = @codigo_postal
		SET @resultado='El nombre se modifico'	
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='Se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

--modificar direccion sucursal
CREATE PROCEDURE GESDA.modificar_direccion_sucursal (@codigo_postal Varchar(255), @direccion_nuevo Varchar(255), @resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Sucursal
		SET sucursal_direccion = @direccion_nuevo
		WHERE sucursal_codigo_postal = @codigo_postal
		SET @resultado='La direccion se modifico'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='Se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

--modificar codigo postal sucursal
CREATE PROCEDURE GESDA.modificar_cosdigo_postal_sucursal (@codigo_postal Varchar(255), @codigo_postal_nuevo Varchar(255), @resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Sucursal
		SET sucursal_codigo_postal = @codigo_postal_nuevo
		WHERE sucursal_codigo_postal=@codigo_postal
		SET @resultado='El codigo postal se modifico'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='Se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

/***************************************/
/********* ABM FACTURAS*********/
/***************************************/

--ALTA FACTURAS
CREATE PROCEDURE GESDA.guardar_factura (@mail_cliente Varchar(255) ,@cuit_empresa Varchar(255), @numero_factura Numeric(18,0), @fecha_alta Datetime, @fecha_vencimiento Datetime, @total Numeric(18,2), @resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		BEGIN
			
			DECLARE @id_cliente Numeric(18,0)
			DECLARE @id_empresa Numeric(18,0)
			SET @id_cliente = (SELECT id_cliente FROM GESDA.Cliente WHERE  cliente_mail = @mail_cliente)
			SET @id_empresa = (SELECT id_empresa FROM GESDA.Empresa WHERE empresa_cuit = @cuit_empresa)

			IF EXISTS (SELECT * FROM GESDA.Cliente WHERE cliente_mail = @mail_cliente)
				BEGIN
					IF EXISTS (SELECT * FROM GESDA.Empresa WHERE empresa_cuit = @cuit_empresa)
						BEGIN
							IF NOT EXISTS (SELECT * FROM GESDA.Factura WHERE id_empresa=(SELECT id_empresa FROM GESDA.Empresa WHERE empresa_cuit=@cuit_empresa) AND factura_numero=@numero_factura)
								BEGIN
									INSERT INTO GESDA.Factura (id_cliente, id_empresa, factura_numero, factura_fecha_alta, factura_fecha_vencimiento, factura_total, factura_estado)
									VALUES (@id_cliente,@id_empresa, @numero_factura, @fecha_alta, @fecha_vencimiento, @total, 1)
									SET @resultado='La factura se pudo dar de alta' 
								END
							ELSE
								BEGIN
									SET @resultado='La factura no se puede dar de alta, porque el Nro de factura para esta empresa ya existe'
								END
						END
					ELSE
						BEGIN
							SET @resultado='La factura no se pudo dar de alta, porque la empresa ingresada no existe'
						END
				END
			ELSE
				BEGIN
					SET @resultado='La factura no se pudo dar de alta, porque el cliente ingresado no existe'
				END 
		END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

--Agregar Item
CREATE PROCEDURE GESDA.agregar_item (@id_factura Numeric(18,0), @monto Numeric(18,2),@cantidad Numeric(18,0), @descripcion Varchar(255),@resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO GESDA.Factura_Detalle (id_factura, factura_detalle_descripcion, factura_detalle_monto, factura_detalle_cantidad)
		VALUES (@id_factura, @descripcion, @monto, @cantidad)
		SET @resultado='El item se agrego'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

--Agregar item en la pantalla modificacion
CREATE PROCEDURE GESDA.agregar_item_modificacion (@id_factura Numeric(18,0), @monto Numeric(18,2),@cantidad Numeric(18,0), @descripcion Varchar(255),@resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		IF NOT EXISTS (SELECT * FROM GESDA.Factura_Detalle WHERE id_factura=@id_factura AND factura_detalle_monto=@monto AND factura_detalle_cantidad=@cantidad AND factura_detalle_descripcion=@descripcion)
			BEGIN
				INSERT INTO GESDA.Factura_Detalle (id_factura, factura_detalle_descripcion, factura_detalle_monto, factura_detalle_cantidad)
				VALUES (@id_factura, @descripcion, @monto, @cantidad)
				--SET @resultado='Se agrego el item correctamente'
			END
		ELSE
			BEGIN
				UPDATE GESDA.Factura_Detalle
				SET factura_detalle_monto=@monto,
					factura_detalle_cantidad=@cantidad,
					factura_detalle_descripcion=@descripcion 
				WHERE id_factura=@id_factura
				SET @resultado='item actualizado'
			END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

-- Modificacion CLIENTE FACTURA
-- OBS: La casilla cliente va a ser completada por un mail
CREATE PROCEDURE GESDA.modificacion_cliente_factura (@nuevo_mail_cliente Varchar(255), @id_factura Numeric(18,0), @resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		DECLARE @id_cliente_nuevo Numeric(18,0)
		SET @id_cliente_nuevo = (SELECT id_cliente FROM GESDA.Cliente WHERE cliente_mail = @nuevo_mail_cliente) 
		UPDATE GESDA.Factura
		SET id_cliente = @id_cliente_nuevo
		WHERE id_factura = @id_factura
		SET @resultado='Se modifico el cliente de la factura'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

--Habilitar modificacion
CREATE PROCEDURE GESDA.habilitar_modificacion (@id_factura Numeric(18,0), @resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		IF NOT EXISTS (SELECT * FROM GESDA.Rendicion_Detalle WHERE id_factura = @id_factura)
			BEGIN
			IF  NOT EXISTS (SELECT * FROM GESDA.Pago_Detalle WHERE id_factura = @id_factura)
				BEGIN
					SET @resultado='La factura puede modificarse'
				END
			ELSE
				BEGIN
					IF EXISTS (SELECT * FROM GESDA.Devolucion WHERE id_factura=@id_factura)
						BEGIN
							SET @resultado='La factura puede modificarse'
						END
					ELSE
						BEGIN
							SET @resultado='La factura fue pagada, no puede modificarse.'
						END
				END
			END
		ELSE
			BEGIN
				SET @resultado='La factura fue rendida, no puede modificarse.'
			END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

-- Modificacion EMPRESA FACTURA
CREATE PROCEDURE GESDA.modificacion_empresa_factura (@nuevo_cuit_empresa Varchar(255), @id_factura Numeric(18,0),@resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		DECLARE @id_nuevo_empresa Numeric(18,0)
		SET @id_nuevo_empresa = (SELECT id_empresa FROM GESDA.Empresa WHERE empresa_cuit = @nuevo_cuit_empresa) 
		UPDATE GESDA.Factura
		SET id_empresa = @nuevo_cuit_empresa
		WHERE id_factura = @id_factura
		SET @resultado='Se modifico la empresa de la factura'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

-- Modificacion NUMERO FACTURA
CREATE PROCEDURE GESDA.modificacion_numero_factura (@factura_numero_nuevo Numeric(18,0), @id_factura Numeric(18,0),@resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Factura
		SET factura_numero = @factura_numero_nuevo
		WHERE id_factura = @id_factura
		SET @resultado='Se modifico el numero de la factura'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO


-- Modificacion FECHA ALTA FACTURA
CREATE PROCEDURE GESDA.modificacion_fecha_alta_factura (@factura_fecha_alta Datetime, @id_factura Numeric(18,0),@resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Factura
		SET factura_fecha_alta = @factura_fecha_alta
		WHERE id_factura = @id_factura
		SET @resultado='Se modifico la fecha de alta de la factura'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

-- Modificacion FECHA VENCIMIENTO FACTURA
CREATE PROCEDURE GESDA.modificacion_fecha_venc_factura (@factura_fecha_vencimiento Datetime, @id_factura Numeric(18,0),@resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Factura
		SET factura_fecha_vencimiento = @factura_fecha_vencimiento
		WHERE id_factura = @id_factura
		SET @resultado='Se modifico la fecha de vencimiento de la factura'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

-- Modificacion TOTAL FACTURA
CREATE PROCEDURE GESDA.modificacion_total_factura (@factura_total_nuevo Numeric(18,2), @id_factura Numeric(18,0),@resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GESDA.Factura
		SET factura_total = @factura_total_nuevo
		WHERE id_factura = @id_factura
		SET @resultado='Se modifico el total de la factura'
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

-- DESHABILITAR FACTURA
CREATE PROCEDURE GESDA.deshabilitar_factura (@id_factura Numeric(18,0), @resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		BEGIN
			--IF NOT EXISTS (SELECT * FROM GESDA.Rendicion_Detalle WHERE id_factura = @id_factura)
				--BEGIN
					UPDATE GESDA.Factura
					SET factura_estado = 2
					WHERE id_factura = @id_factura
					SET @resultado='Se deshabilito la factura'
				--END
			--ELSE
				--BEGIN
					--SET @resultado='La factura no se puede deshabilitar, fue rendida'
				--END
		END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

-- HABILITRA FACTURA
CREATE PROCEDURE GESDA.habilitar_factura (@id_factura Numeric(18,0),@resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
			BEGIN
				UPDATE GESDA.Factura
				SET factura_estado = 1
				WHERE id_factura = @id_factura
				SET @resultado='Se habilito la factura'
			END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

-- Elimar Items de Factura modificada
CREATE PROCEDURE GESDA.eliminar_items (@id_factura Numeric(18,0))
AS
BEGIN TRY
	DECLARE @resultado Varchar(255) 
	BEGIN TRANSACTION
		BEGIN
			DELETE FROM GESDA.Factura_Detalle
			WHERE id_factura = @id_factura
			SET @resultado='Se borraron los items de esta factura' 
		END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado='No se pudieron borrar los items'
END CATCH
GO

--GUARDAR FACTURA MODIFICADA con num factura distinto
CREATE PROCEDURE GESDA.guardar_factura_modificada_nro_factura_distinto (@id_factura Numeric(18,0), @mail_cliente Varchar(255) ,@cuit_empresa Varchar(255), @numero_factura Numeric(18,0), @fecha_alta Datetime, @fecha_vencimiento Datetime, @total Numeric(18,2), @resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		BEGIN
			
			DECLARE @id_cliente Numeric(18,0)
			DECLARE @id_empresa Numeric(18,0)
			SET @id_cliente = (SELECT id_cliente FROM GESDA.Cliente WHERE  cliente_mail = @mail_cliente)
			SET @id_empresa = (SELECT id_empresa FROM GESDA.Empresa WHERE empresa_cuit = @cuit_empresa)

			IF EXISTS (SELECT * FROM GESDA.Cliente WHERE cliente_mail = @mail_cliente)
				BEGIN
					IF EXISTS (SELECT * FROM GESDA.Empresa WHERE empresa_cuit = @cuit_empresa)
						BEGIN
							IF NOT EXISTS (SELECT * FROM GESDA.Factura WHERE id_empresa=(SELECT id_empresa FROM GESDA.Empresa WHERE empresa_cuit=@cuit_empresa) AND factura_numero=@numero_factura)
								BEGIN
									IF NOT EXISTS (SELECT * FROM GESDA.Rendicion_Detalle WHERE id_factura = @id_factura)
										BEGIN
											IF  NOT EXISTS (SELECT * FROM GESDA.Pago_Detalle WHERE id_factura = @id_factura)
												BEGIN
													UPDATE GESDA.Factura
													SET id_cliente = @id_cliente, 
														id_empresa = @id_empresa,
														factura_numero = @numero_factura,
														factura_fecha_alta = @fecha_alta,
														factura_fecha_vencimiento = @fecha_vencimiento,
														factura_total = @total,
														factura_estado = 1
													WHERE id_factura = @id_factura
													SET @resultado='La factura se modifico' 
													EXECUTE GESDA.eliminar_items @id_factura
												END
											ELSE
												BEGIN
													SET @resultado='La factura no se puede modificar, fue pagada'
												END
										END
									ELSE
										BEGIN
											SET @resultado='La factura no se puede modificar, fue rendida'
										END
								END
							ELSE
								BEGIN
									SET @resultado='La factura no se puede modificar, el num de factura de esta empresa ya existe'
								END
						END
					ELSE
						BEGIN
							SET @resultado='La factura no se pudo modificar, porque la empresa ingresada no existe'
						END
				END
			ELSE
				BEGIN
					SET @resultado='La factura no se pudo modificar, porque el cliente ingresado no existe'
				END 
		END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

---GUARDAR FACTURA MODIFICADA con num factura igual
CREATE PROCEDURE GESDA.guardar_factura_modificada_nro_factura_igual (@id_factura Numeric(18,0), @mail_cliente Varchar(255) ,@cuit_empresa Varchar(255), @numero_factura Numeric(18,0), @fecha_alta Datetime, @fecha_vencimiento Datetime, @total Numeric(18,2), @resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		BEGIN
			
			DECLARE @id_cliente Numeric(18,0)
			DECLARE @id_empresa Numeric(18,0)
			SET @id_cliente = (SELECT id_cliente FROM GESDA.Cliente WHERE  cliente_mail = @mail_cliente)
			SET @id_empresa = (SELECT id_empresa FROM GESDA.Empresa WHERE empresa_cuit = @cuit_empresa)

			IF EXISTS (SELECT * FROM GESDA.Cliente WHERE cliente_mail = @mail_cliente)
				BEGIN
					IF EXISTS (SELECT * FROM GESDA.Empresa WHERE empresa_cuit = @cuit_empresa)
						BEGIN
							IF NOT EXISTS (SELECT * FROM GESDA.Rendicion_Detalle WHERE id_factura = @id_factura)
								BEGIN
									IF  NOT EXISTS (SELECT * FROM GESDA.Pago_Detalle WHERE id_factura = @id_factura)
										BEGIN
											UPDATE GESDA.Factura
											SET id_cliente = @id_cliente, 
												id_empresa = @id_empresa,
												factura_numero = @numero_factura,
												factura_fecha_alta = @fecha_alta,
												factura_fecha_vencimiento = @fecha_vencimiento,
												factura_total = @total,
												factura_estado = 1
											WHERE id_factura = @id_factura
											SET @resultado='La factura se modifico' 
											EXECUTE GESDA.eliminar_items @id_factura
										END
									ELSE
										BEGIN
											SET @resultado='La factura no se puede modificar, fue pagada'
										END
								END
							ELSE
								BEGIN
									SET @resultado='La factura no se puede modificar, fue rendida'
								END
						END
					ELSE
						BEGIN
							SET @resultado='La factura no se pudo modificar, porque la empresa ingresada no existe'
						END
				END
			ELSE
				BEGIN
					SET @resultado='La factura no se pudo modificar, porque el cliente ingresado no existe'
				END 
		END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION 
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO

CREATE PROCEDURE GESDA.eliminar_items_alta (@id_factura Numeric(18,0), @resultado Varchar(255) OUT)
AS
BEGIN TRY
	BEGIN TRANSACTION
		BEGIN
			DECLARE @total Numeric(18,2)
			DECLARE @sumMontos Numeric(18,2)
			SET @total = (SELECT factura_total from GESDA.Factura WHERE id_factura=@id_factura) 
			SET @sumMontos =(SELECT SUM(factura_detalle_monto) AS total_monto from GESDA.Factura_Detalle WHERE id_factura=@id_factura)
			IF (@total = @sumMontos)
				BEGIN
					SET @resultado='La sumatoria de montos coinciden con el total'
				END
			ELSE
				BEGIN
					DELETE FROM GESDA.Factura_Detalle
					WHERE id_factura = @id_factura
					SET @resultado='La sumatoria de montos no coincide con el total' 
				END			
		END 
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SET @resultado='se produjo un error en: '+ERROR_PROCEDURE()
END CATCH
GO