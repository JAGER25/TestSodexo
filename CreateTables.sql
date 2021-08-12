-- Generado por Oracle SQL Developer Data Modeler 21.2.0.183.1957
--   en:        2021-08-12 04:13:29 COT
--   sitio:      Oracle Database 12cR2
--   tipo:      Oracle Database 12cR2



DROP TABLE facturas CASCADE CONSTRAINTS;

DROP TABLE facturas_productos CASCADE CONSTRAINTS;

DROP TABLE productos CASCADE CONSTRAINTS;

-- predefined type, no DDL - MDSYS.SDO_GEOMETRY

-- predefined type, no DDL - XMLTYPE

CREATE TABLE facturas (
    idfactura        INTEGER GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) NOT NULL,
    numerofactura    VARCHAR2(50) NOT NULL,
    fecha            DATE,
    tipopago         INTEGER NOT NULL,
    documentocliente VARCHAR2(30),
    nombrecliente    VARCHAR2(200),
    subtotal         NUMBER(20, 2),
    descuento        NUMBER(20, 2),
    iva              INTEGER,
    totaldescuento   NUMBER(20, 2),
    totalimpuesto    NUMBER(20, 2),
    total            NUMBER(20, 2)
);

ALTER TABLE facturas ADD CONSTRAINT facturas_pk PRIMARY KEY ( idfactura );

CREATE TABLE facturas_productos (
    idfacturaproductos   INTEGER GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) NOT NULL,
    facturas_idfactura   INTEGER NOT NULL,
    productos_idproducto INTEGER NOT NULL
);

ALTER TABLE facturas_productos ADD CONSTRAINT facturas_productos_pk PRIMARY KEY ( idfacturaproductos );

CREATE TABLE productos (
    idproducto INTEGER GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) NOT NULL,
    nombre     VARCHAR2(150),
    precio     NUMBER(20, 2)
);

ALTER TABLE productos ADD CONSTRAINT productos_pk PRIMARY KEY ( idproducto );

ALTER TABLE facturas_productos
    ADD CONSTRAINT facturas_productos_facturas_fk FOREIGN KEY ( facturas_idfactura )
        REFERENCES facturas ( idfactura );

ALTER TABLE facturas_productos
    ADD CONSTRAINT facturas_producto_productos_fk FOREIGN KEY ( productos_idproducto )
        REFERENCES productos ( idproducto );




