using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ways.Model
{
    class Skill
    {
        private string name;
        private List<Job> jobs;

        public Skill(string SkillName, List<Job> JobList)
        {
            Name = SkillName;
            Jobs = JobList;
        }

        public Skill()
        {

        }

        public string Name { get => name; set => name = value; }
        public List<Job> Jobs { get => jobs; set => jobs = value; }

        public List<Skill> SelectSkills(List<Job> jobs)
        {
            List<Skill> skills = new List<Skill>();

            #region Disponibilité
            List<Job> disponibiliteJobs = new List<Job>();
            for (int i = 0; i < jobs.Count(); i++)
            {
                if (jobs[i].Name == "Technicien / Gestionnaire maintenance informatique" ||
                   jobs[i].Name == "Chef de projet informatique / Maîtrise d’oeuvre" ||
                   jobs[i].Name == "Ingénieur en cybersécurité")
                {
                    disponibiliteJobs.Add(jobs[i]);
                }
            }
            Skill disponibilite = new Skill("Disponibilité", disponibiliteJobs);
            skills.Add(disponibilite);
            #endregion

            #region Relationnel
            List<Job> relationnelJobs = new List<Job>();
            for (int i = 0; i < jobs.Count(); i++)
            {
                if (jobs[i].Name == "Technicien / Gestionnaire maintenance informatique" ||
                   jobs[i].Name == "Chef de projet informatique / Maîtrise d’oeuvre" ||
                   jobs[i].Name == "Administrateur systèmes & réseaux" ||
                   jobs[i].Name == "Architecte cloud")
                {
                    relationnelJobs.Add(jobs[i]);
                }
            }
            Skill relationnel = new Skill("Relationnel", relationnelJobs);
            skills.Add(relationnel);
            #endregion

            #region Redactionnel
            List<Job> redactionnelJobs = new List<Job>();
            for (int i = 0; i < jobs.Count(); i++)
            {
                if (jobs[i].Name == "Chef de projet informatique / Maîtrise d’oeuvre" ||
                   jobs[i].Name == "Administrateur systèmes & réseaux" ||
                   jobs[i].Name == "Architecte cloud" ||
                   jobs[i].Name == "Data analyst")
                {
                    redactionnelJobs.Add(jobs[i]);
                }
            }
            Skill redactionnel = new Skill("Redactionnel", redactionnelJobs);
            skills.Add(redactionnel);
            #endregion

            #region Polyvalence
            List<Job> polyvalenceJobs = new List<Job>();
            for (int i = 0; i < jobs.Count(); i++)
            {
                if (jobs[i].Name == "Analyste programmeur" ||
                   jobs[i].Name == "Administrateur systèmes & réseaux" ||
                   jobs[i].Name == "Responsable en ingénierie des logiciels")
                {
                    polyvalenceJobs.Add(jobs[i]);
                }
            }
            Skill polyvalence = new Skill("Polyvalence", polyvalenceJobs);
            skills.Add(polyvalence);
            #endregion

            #region Anticipation
            List<Job> anticipationJobs = new List<Job>();
            for (int i = 0; i < jobs.Count(); i++)
            {
                if (jobs[i].Name == "Administrateur systèmes & réseaux" ||
                   jobs[i].Name == "Responsable en ingénierie des logiciels" ||
                   jobs[i].Name == "Architecte cloud" ||
                   jobs[i].Name == "Ingénieur en cybersécurité" ||
                   jobs[i].Name == "Data analyst")
                {
                    anticipationJobs.Add(jobs[i]);
                }
            }
            Skill anticipation = new Skill("Anticipation", anticipationJobs);
            skills.Add(anticipation);
            #endregion

            #region Collaboration
            List<Job> collaborationJobs = new List<Job>();
            for (int i = 0; i < jobs.Count(); i++)
            {
                if (jobs[i].Name == "Chef de projet informatique / Maîtrise d’oeuvre" ||
                   jobs[i].Name == "Analyste programmeur")
                {
                    collaborationJobs.Add(jobs[i]);
                }
            }
            Skill collaboration = new Skill("Collaboration", collaborationJobs);
            skills.Add(collaboration);
            #endregion

            #region Ethique
            List<Job> ethiqueJobs = new List<Job>();
            for (int i = 0; i < jobs.Count(); i++)
            {
                if (jobs[i].Name == "Technicien / Gestionnaire maintenance informatique" ||
                   jobs[i].Name == "Architecte cloud" ||
                   jobs[i].Name == "Ingénieur en cybersécurité" ||
                   jobs[i].Name == "Data analyst")
                {
                    ethiqueJobs.Add(jobs[i]);
                }
            }
            Skill ethique = new Skill("Ethique", ethiqueJobs);
            skills.Add(ethique);
            #endregion

            #region Logique
            List<Job> logiqueJobs = new List<Job>();
            for (int i = 0; i < jobs.Count(); i++)
            {
                if (jobs[i].Name == "Analyste programmeur" ||
                   jobs[i].Name == "Responsable en ingénierie des logiciels" ||
                   jobs[i].Name == "Ingénieur en cybersécurité")
                {
                    logiqueJobs.Add(jobs[i]);
                }
            }
            Skill logique = new Skill("Logique", logiqueJobs);
            skills.Add(logique);
            #endregion

            #region Autonomie
            List<Job> autonomieJobs = new List<Job>();
            for (int i = 0; i < jobs.Count(); i++)
            {
                if (jobs[i].Name == "Technicien / Gestionnaire maintenance informatique" ||
                   jobs[i].Name == "Analyste programmeur" ||
                   jobs[i].Name == "Responsable en ingénierie des logiciels" ||
                   jobs[i].Name == "Data analyst")
                {
                    autonomieJobs.Add(jobs[i]);
                }
            }
            Skill autonomie = new Skill("Autonomie", autonomieJobs);
            skills.Add(autonomie);
            #endregion

            return skills;
        }
    }
}
