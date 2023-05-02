
CREATE TABLE IF NOT EXISTS public."TagReportTasks"
(
    "Id" serial NOT NULL,
    "LastSendDt" timestamp without time zone NULL,
    "IsActive" bool NOT NULL,
    "FactoryId" integer NOT NULL,
    CONSTRAINT "TagReportTasks_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "TagReportTasks_FactoryId_key" UNIQUE ("FactoryId"),
    CONSTRAINT "FK_TagReportTasks_Factories_FactoryId" FOREIGN KEY ("FactoryId")
    REFERENCES public."Factories" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE
    );

CREATE TABLE IF NOT EXISTS public."WorkEmails"
(
    "Id" serial NOT NULL,
    "Email" text NOT NULL,
    CONSTRAINT "WorkEmails_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "WorkEmails_Email_key" UNIQUE ("Email")

    );

CREATE TABLE public."TagLiveReportsWorkEmails" (
                                                   "Id" integer NOT NULL DEFAULT nextval('"TagLiveReportsWorkEmails_Id_seq"'::regclass),
                                                   "TagLiveReportId" integer NOT NULL,
                                                   "WorkEmailId" integer NOT NULL,
                                                   CONSTRAINT "TagLiveReportsWorkEmails_pkey" PRIMARY KEY ("Id"),
                                                   CONSTRAINT "FK_TagLiveReportsWorkEmails_TagLiveReports_TagLiveReportId" FOREIGN KEY ("TagLiveReportId")
                                                       REFERENCES public."TagLiveReports" ("Id") MATCH SIMPLE
                                                       ON UPDATE NO ACTION
                                                       ON DELETE CASCADE,
                                                   CONSTRAINT "FK_UsersFactories_WorkEmails_WorkEmailId" FOREIGN KEY ("WorkEmailId")
                                                       REFERENCES public."WorkEmails" ("Id") MATCH SIMPLE
                                                       ON UPDATE NO ACTION
                                                       ON DELETE CASCADE
);
--Another variant
CREATE TABLE public."TagReportTasksWorkEmails" (
                                                   "Id" serial NOT NULL,
                                                   "TagReportTaskId"    int REFERENCES "TagReportTasks" ("Id") ON UPDATE CASCADE ON DELETE CASCADE,
                                                   "WorkEmailId" int REFERENCES "WorkEmails" ("Id") ON UPDATE CASCADE,
                                                   CONSTRAINT "TagReportTasksWorkEmails_pkey" PRIMARY KEY ("Id"),
                                                   CONSTRAINT "TagReportTasksWorkEmail_key" UNIQUE ("TagReportTaskId", "WorkEmailId")  -- explicit pk
);



--ADD Column
ALTER TABLE "TagReportTasks"
    Add "Status" INT NOT NULL DEFAULT 0;