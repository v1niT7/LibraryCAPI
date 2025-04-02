CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TABLE "Books" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL,
    "Author" text NOT NULL,
    "PublicationYear" integer NOT NULL,
    "Gender" text NOT NULL,
    "Price" double precision NOT NULL,
    "ImageUrl" text NOT NULL,
    CONSTRAINT "PK_Books" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250329141038_Initial', '9.0.3');

COMMIT;

