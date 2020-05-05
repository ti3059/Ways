using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{
    class Job
    {
        private string name;
        private string des;
        private List<string> tasks;
        private List<string> skills;
        private int countValue = 0;

        public Job(string JobName, string JobDes, List<string> JobTasks, List<string> JobSkills, int value)
        {
            Name = JobName;
            Des = JobDes;
            Tasks = JobTasks;
            value = countValue;
        }

        public string Name { get => name; set => name = value; }
        public List<string> Tasks { get => tasks; set => tasks = value; }
        public int CountValue { get => countValue; set => countValue = value; }
        public string Des { get => des; set => des = value; }

        public List<Job> SelectJobs()
        {
            List<Job> jobs = new List<Job>();

            #region Technicien Gestionnaire Maintenance Informatique
            List<string> LstTechGestMaintInfoTasks = new List<string>();
            LstTechGestMaintInfoTasks.Add("assurer la réparation des pannes informatiques");
            LstTechGestMaintInfoTasks.Add("assurer la résolution des dysfonctionnements d'un logiciel ou d'un ordinateur");
            LstTechGestMaintInfoTasks.Add("assurer la réalisation de diagnostics pour mieux réparer");
            LstTechGestMaintInfoTasks.Add("assurer l'installation de nouveaux équipements informatiques au sein d'une entreprise");

            Job jobTechGestMaintInfo = new Job("Technicien / Gestionnaire maintenance informatique", "Intervenant généralement dans l’urgence, le technicien / gestionnaire de maintenance est appelé pour résoudre " +
                "une panne matériel ou logiciel. Il doit être capable d’établir un diagnostic sûre et rapide. Proche des utilisateurs, il peut en assurer la formation et cherche avant tout à prevenire " +
                "le problème. Pleinement renseigné sur les équipements et les outils en question, il doit se tenir à l'affût des nouveautés afin de faire évoluer ses connaissances. " +
                "Enfin son rôle sera d’installer et de maintenire à jours les différents outils et matériels.",
                LstTechGestMaintInfoTasks, 0
                );

            jobs.Add(jobTechGestMaintInfo);
            #endregion

            #region Chef de projet informatique / Maîtrise d’oeuvre
            List<string> LstChefProjInfoTasks = new List<string>();
            LstTechGestMaintInfoTasks.Add("réaliser la conception d’un cahier des charges pour adapter une solution à la demande d’un client");
            LstTechGestMaintInfoTasks.Add("réaliser un suivi constant du projet");
            LstTechGestMaintInfoTasks.Add("respecter les coûts et délais, dans le cas contraire prévoir et gérer les écartsr");
            LstTechGestMaintInfoTasks.Add("prévoir la mise en place des solutions chez le client et de son suivis");

            Job jobChefProjInfo = new Job("Chef de projet informatique / Maîtrise d’oeuvre",
                "Expert en informatique, le chef de projet informatique / MOA se doit d’avoir un certain bagage dans le domaine (cette expérience n’est pas invariable mais sera fortement priorisée dans la majeure partie des cas). Parfois avec un ou plusieurs informaticiens placés sous ses ordres pour répondre aux demandes de clients particuliers, il doit posséder des compétences à la fois techniques et managériales.",
                LstTechGestMaintInfoTasks, 0
                );

            jobs.Add(jobChefProjInfo);
            #endregion

            #region Analyste programmeur
            List<string> LstAnalysteProgrammeurTasks = new List<string>();
            LstAnalysteProgrammeurTasks.Add("réaliser la conception d’un cahier des charges pour adapter une solution à la demande d’un client");
            LstAnalysteProgrammeurTasks.Add("réaliser un suivi constant du projet");
            LstAnalysteProgrammeurTasks.Add("respecter les coûts et délais, dans le cas contraire prévoir et gérer les écartsr");
            LstAnalysteProgrammeurTasks.Add("prévoir la mise en place des solutions chez le client et de son suivis");

            Job jobAnalysteProgrammeur = new Job("Analyste programmeur",
                "Directement dans la conception et/ou l’amélioration des programmes informatiques, l’analyste programmeur doit organiser une solution technique après une traduction des besoins de l’utilisateur. Il peut s’occuper de la réalisation d’un cahier des charges décrivant les solutions techniques. Son environnement de travail est capital à son travail, il utilise une collection d’outils qu’il adapte de manières spécifiques pour son programme. Présent dans toutes les phases du projet il est un pivot majeure dans la production des solutions informatique.",
                LstAnalysteProgrammeurTasks, 0
                );

            jobs.Add(jobAnalysteProgrammeur);
            #endregion

            #region Administrateur Systèmes et Réseaux
            List<string> LstAdminSysResTasks = new List<string>();
            LstAdminSysResTasks.Add("analyser les besoins des utilisateurs du réseau : qualité, rapidité, sécurité");
            LstAdminSysResTasks.Add("définir les besoins d’extension ou de modification des équipements");
            LstAdminSysResTasks.Add("configurer le matériel et les logiciels à intégrer au réseau");
            LstAdminSysResTasks.Add("mettre en place et contrôler les procédures de sécurité (droits d’accès, mots de passe…)");
            LstAdminSysResTasks.Add("apporter son aide aux utilisateurs sur une anomalie liée au réseau");
            LstAdminSysResTasks.Add("prévenir les dysfonctionnements et les pannes de fonctionnement du réseau");
            LstAdminSysResTasks.Add("réaliser de la veille technologique");

            Job jobAdminSysRes = new Job("Administrateur systèmes & réseaux",
                "Avec de solides connaissances en matière de systèmes d’exploitation, de réseau, de sécurité mais également de stockage, l’ Administrateur Systèmes et Réseaux est, avec son équipe, en charge d’assurer le bon fonctionnement des services. Il se doit d’être très attentif à ce qu’il met en place car les répercutions peuvent être lourdes de conséquences. Une erreur de sa part et d’importantes données durement acquises en entreprises peuvent être perdu à jamais. Sa rigueur et son attention sont essentielles pour garantir le support technique et la maintenance des services.Des capacités en Hardware lui seront également nécessaires concernant le matériel.",
                LstAdminSysResTasks, 0
                );

            jobs.Add(jobAdminSysRes);
            #endregion

            #region Responsable en ingénierie des logiciels

            //Responsable en ingénierie des logiciels
            List<string> LstRespIngLogTasks = new List<string>();
            LstAdminSysResTasks.Add("analyser et comprendre les besoins de son entreprise (automatisation, évolution) pour mieux proposer les solutions adéquates");
            LstAdminSysResTasks.Add("concevoir des solutions informatiques en fonction des demandes formulées par l’administration");
            LstAdminSysResTasks.Add("participer à la mise en œuvre des solutions ainsi créées et contribuer à leur développement");
            LstAdminSysResTasks.Add("effectuer des tests pour vérifier le bon fonctionnement des outils et procéder aux rectifications, si nécessaire, avant de les commercialiser");

            Job jobRespIngLog = new Job("Responsable en ingénierie des logiciels",
                "Le responsable en ingénierie des logiciels élabore des applications logicielles innovantes et efficaces pour le compte de son entreprise, tout en tenant compte des contraintes temporelles, financières et sécuritaires imposées par ses responsables hiérarchiques et par le projet lui-même.",
                LstRespIngLogTasks, 0
                );

            jobs.Add(jobRespIngLog);
            #endregion

            #region Architecte cloud
            List<string> LstArchCloudTasks = new List<string>();
            LstAdminSysResTasks.Add("mettre en place une sécurité des données adaptée aux besoins de l’entreprise");
            LstAdminSysResTasks.Add("réaliser des tests techniques et fonctionnels");
            LstAdminSysResTasks.Add("former les utilisateurs sur la solutions déployée");
            LstAdminSysResTasks.Add("réaliser un suivi/une maintenance du nouveau système");

            Job jobArchCloud = new Job("Architect cloud",
                "Veillant à la sécurisation des données sensibles de son entreprise, l’architecte cloud guide les entreprises dans leur mutation vers le traitement de données. Son rôle est de mettre en place les nouvelles solutions de stockages de données en réalisant une analyse des besoins.",
                LstArchCloudTasks, 0
                );

            jobs.Add(jobArchCloud);
            #endregion

            #region Ingénieur Cybersécurité
            List<string> LstIngCybersecuTasks = new List<string>();
            LstAdminSysResTasks.Add("superviser et administrer en toute confidentialité les solutions du Security Operating Center (SOC)");
            LstAdminSysResTasks.Add("détecter, analyser et qualifier les incidents, les menaces et les attaques cyber");
            LstAdminSysResTasks.Add("identifier leurs sources, leurs mécanismes et bloquer leur accès aux solutions existantes");
            LstAdminSysResTasks.Add("garantir l’analyse des différentes données informatiques");
            LstAdminSysResTasks.Add("orienter les équipes techniques quant aux correctifs ou palliatifs à mettre en œuvre pour sécuriser le réseau et les systèmes informatiques");
            LstAdminSysResTasks.Add("rédiger des procédures de sécurité adaptées et sensibiliser aux enjeux de la sécurité du réseau, de la data et des systèmes informatiquess");
            LstAdminSysResTasks.Add("veiller à leur application et à leur exploitabilité par tous les utilisateurs");
            LstAdminSysResTasks.Add("Assurer une veille permanente sur les menaces actuelles et la cyberdéfense");
            LstAdminSysResTasks.Add("Documenter les bases de connaissances et procédures de traitement");
            LstAdminSysResTasks.Add("Suivre constamment la vulnérabilité software et hardware");
            LstAdminSysResTasks.Add("Analyser les malwares et l’ensemble des violations de données");

            Job jobIngCyber = new Job("Ingénieur en cybersécurité",
                "L’Ingénieur Cybersécurité participe à la définition des règles de sécurité applicatives et logiques en réponse aux exigences fixées par des référentiels de bonnes pratiques ou par des réglementations propres à l’activité de l’entreprise. Il est également en charge d’analyser, de traiter les menaces d’intrusion et de définir les plans d’action nécessaires à leurs corrections ou leur anticipation. ",
                LstIngCybersecuTasks, 0
                );

            jobs.Add(jobIngCyber);
            #endregion

            #region Data analyst
            List<string> LstDataAnalystTasks = new List<string>();
            LstAdminSysResTasks.Add("maîtriser les outils statistiques et les informations nécessaires à la mise en place d'une base de données");
            LstAdminSysResTasks.Add("extraire les données du système source et traduire ces données business en données statistiques");
            LstAdminSysResTasks.Add("synthétiser et vulgariser les informations pour les rendre accessibles aux dirigeants de l'entreprise");
            LstAdminSysResTasks.Add("proposer des recommandations sur les bases de données à modifier");
            LstAdminSysResTasks.Add("définir la cible des campagnes de marketing");
            LstAdminSysResTasks.Add("déterminer des tendances d'achat ou de consommation");
            LstAdminSysResTasks.Add("faciliter les prises de décision des entreprises en assurant un rôle de consultant");

            Job jobDataAnalyst = new Job("Data analyst",
                "Le Data Analyst est l’un des métiers né grâce au Big Data. Il est chargé de traiter les données à disposition de l’entreprise afin d’en extraire des informations permettant de stimuler la croissance de l’entreprise et d’aiguiller sa stratégie. Son rôle est de donner un sens aux données, de les transformer en informations exploitables.",
                LstDataAnalystTasks, 0
                );

            jobs.Add(jobDataAnalyst);
            #endregion

            return jobs;
        }

    }
}
