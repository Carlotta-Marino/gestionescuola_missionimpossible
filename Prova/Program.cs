﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Prova
{
    internal class Program
    {
        static string filePath = "C:\\Users\\User23_12_1\\Desktop\\Prova\\school_data.txt";
        static List<Classe> classi = new List<Classe>();
        static List<Studente> studenti = new List<Studente>();
        static List<Insegnante> insegnanti = new List<Insegnante>();
        static List<Valutazione> valutazioni = new List<Valutazione>();
        static void Main(string[] args)
        {
            LoadDataFromFile(); // Carica i dati dal file di testo

            while (true)
            {
                Console.WriteLine("=== Menu ===");
                Console.WriteLine("1. Gestione Classi");
                Console.WriteLine("2. Gestione Studenti");
                Console.WriteLine("3. Gestione Insegnanti");
                Console.WriteLine("4. Gestione Valutazioni");
                Console.WriteLine("5. Uscita");
                Console.WriteLine("============");

                Console.Write("Seleziona un'opzione: ");
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ManageClassi();
                        break;
                    case "2":
                        ManageStudenti();
                        break;
                    case "3":
                        ManageInsegnanti();
                        break;
                    case "4":
                        ManageValutazioni();
                        break;
                    case "5":
                        SaveDataToFile();
                        return;
                    default:
                        Console.WriteLine("Opzione non valida. Riprova.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ManageClassi()
        {
            Console.WriteLine("=== Gestione Classi ===");
            Console.WriteLine("1. Visualizza Classi");
            Console.WriteLine("2. Aggiungi Classe");
            Console.WriteLine("3. Modifica Classe");
            Console.WriteLine("4. Cancella Classe");
            Console.WriteLine("=======================");

            Console.Write("Seleziona un'opzione: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    VisualizzaClassi();
                    break;
                case "2":
                    AggiungiClasse();
                    break;
                case "3":
                    ModificaClasse();
                    break;
                case "4":
                    CancellaClasse();
                    break;
                default:
                    Console.WriteLine("Opzione non valida. Riprova.");
                    break;
            }
        }

        static void VisualizzaClassi()
        {
            Console.WriteLine("=== Classi Disponibili ===");
            foreach (var classe in classi)
            {
                Console.WriteLine($"ID: {classe.IDClasse} Nome: {classe.NomeClasse}");
            }
        }

        static void AggiungiClasse()
        {
            Console.WriteLine("=== Aggiungi Classe ===");
            Console.Write("Inserisci l'ID della classe: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Inserisci il nome della classe: ");
            string nome = Console.ReadLine();
            

            Classe nuovaClasse = new Classe(id, nome);
            classi.Add(nuovaClasse);

            Console.WriteLine("Classe aggiunta con successo.");
        }

        static void ModificaClasse()
        {
            Console.WriteLine("=== Modifica Classe ===");
            Console.Write("Inserisci l'ID della classe da modificare: ");
            int id = int.Parse(Console.ReadLine());

            Classe classeDaModificare = classi.Find(c => c.IDClasse == id);
            if (classeDaModificare != null)
            {
                Console.Write("Inserisci il nuovo nome della classe: ");
                string nome = Console.ReadLine();

                classeDaModificare.NomeClasse = nome;
                

                Console.WriteLine("Classe modificata con successo.");
            }
            else
            {
                Console.WriteLine("Classe non trovata.");
            }
        }

        static void CancellaClasse()
        {
            Console.WriteLine("=== Cancella Classe ===");
            Console.Write("Inserisci l'ID della classe da cancellare: ");
            int id = int.Parse(Console.ReadLine());

            Classe classeDaCancellare = classi.Find(c => c.IDClasse == id);
            if (classeDaCancellare != null)
            {
                classi.Remove(classeDaCancellare);
                Console.WriteLine("Classe cancellata con successo.");
            }
            else
            {
                Console.WriteLine("Classe non trovata.");
            }
        }

        static void AggiornaClasse()
        {
            List<string> classiAggiornate = new List<string>();

            foreach (var studente in studenti)
            {
                if (!classiAggiornate.Contains(studente.NomeClasse))
                {
                    classiAggiornate.Add(studente.NomeClasse);
                }
            }

            classi = classiAggiornate.Select((nomeClasse, index) => new Classe(index + 1, nomeClasse)).ToList();
        }

        static void ManageStudenti()
        {
            Console.WriteLine("=== Gestione Studenti ===");
            Console.WriteLine("1. Visualizza Studenti");
            Console.WriteLine("2. Aggiungi Studente");
            Console.WriteLine("3. Modifica Studente");
            Console.WriteLine("4. Cancella Studente");
            Console.WriteLine("==========================");

            Console.Write("Seleziona un'opzione: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    VisualizzaStudenti();
                    break;
                case "2":
                    AggiungiStudente();
                    break;
                case "3":
                    ModificaStudente();
                    break;
                case "4":
                    CancellaStudente();
                    break;
                default:
                    Console.WriteLine("Opzione non valida. Riprova.");
                    break;
            }
        }

        static void VisualizzaStudenti()
        {
            Console.WriteLine("=== Studenti Disponibili ===");
            foreach (var studente in studenti)
            {
                Console.WriteLine($"ID: {studente.IDStudente} Nome: {studente.Nome} Cognome: {studente.Cognome} Data di Nascita: {studente.DataNascita} Anno di Corso: {studente.AnnoCorso} Classe: {studente.NomeClasse}");
            }
        }

        static void AggiungiStudente()
        {
            Console.WriteLine("=== Aggiungi Studente ===");
            Console.Write("Inserisci l'ID dello studente: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Inserisci il nome dello studente: ");
            string nome = Console.ReadLine();
            Console.Write("Inserisci il cognome dello studente: ");
            string cognome = Console.ReadLine();
            Console.Write("Inserisci la data di nascita dello studente: ");
            DateOnly dataNascita = DateOnly.Parse(Console.ReadLine());
            Console.Write("Inserisci l'anno di corso dello studente: ");
            int annoCorso = int.Parse(Console.ReadLine());
            Console.Write("Inserisci la classe dello studente: ");
            string nomeClasse = Console.ReadLine();

            Studente nuovoStudente = new Studente(id, nome, cognome, dataNascita, annoCorso, nomeClasse);
            studenti.Add(nuovoStudente);

            Console.WriteLine("Studente aggiunto con successo.");
        }

        static void ModificaStudente()
        {
            Console.WriteLine("=== Modifica Studente ===");
            Console.Write("Inserisci l'ID dello studente da modificare: ");
            int id = int.Parse(Console.ReadLine());

            Studente studenteDaModificare = studenti.Find(s => s.IDStudente == id);
            if (studenteDaModificare != null)
            {
                Console.Write("Inserisci il nuovo nome dello studente: ");
                string nome = Console.ReadLine();
                Console.Write("Inserisci il nuovo cognome dello studente: ");
                string cognome = Console.ReadLine();
                Console.Write("Inserisci la nuova data di nascita dello studente: ");
                DateOnly dataNascita = DateOnly.Parse(Console.ReadLine());
                Console.Write("Inserisci il nuovo anno di corso dello studente: ");
                int annoCorso = int.Parse(Console.ReadLine());
                Console.Write("Inserisci la nuova classe dello studente: ");
                string nomeClasse = Console.ReadLine();

                studenteDaModificare.Nome = nome;
                studenteDaModificare.Cognome = cognome;
                studenteDaModificare.DataNascita = dataNascita;
                studenteDaModificare.AnnoCorso = annoCorso;
                studenteDaModificare.NomeClasse = nomeClasse;

                Console.WriteLine("Studente modificato con successo.");
            }
            else
            {
                Console.WriteLine("Studente non trovato.");
            }
        }

        static void CancellaStudente()
        {
            Console.WriteLine("=== Cancella Studente ===");
            Console.Write("Inserisci l'ID dello studente da cancellare: ");
            int id = int.Parse(Console.ReadLine());

            Studente studenteDaCancellare = studenti.Find(s => s.IDStudente == id);
            if (studenteDaCancellare != null)
            {
                studenti.Remove(studenteDaCancellare);
                Console.WriteLine("Studente cancellato con successo.");
            }
            else
            {
                Console.WriteLine("Studente non trovato.");
            }
        }


        static void ManageInsegnanti()
        {
            Console.WriteLine("=== Gestione Insegnanti ===");
            Console.WriteLine("1. Visualizza Insegnanti");
            Console.WriteLine("2. Aggiungi Insegnante");
            Console.WriteLine("3. Modifica Insegnante");
            Console.WriteLine("4. Cancella Insegnante");
            Console.WriteLine("===========================");

            Console.Write("Seleziona un'opzione: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    VisualizzaInsegnanti();
                    break;
                case "2":
                    AggiungiInsegnante();
                    break;
                case "3":
                    ModificaInsegnante();
                    break;
                case "4":
                    CancellaInsegnante();
                    break;
                default:
                    Console.WriteLine("Opzione non valida. Riprova.");
                    break;
            }
        }

        static void VisualizzaInsegnanti()
        {
            Console.WriteLine("=== Insegnanti Disponibili ===");
            foreach (var insegnante in insegnanti)
            {
                Console.WriteLine($"ID: {insegnante.IDInsegnante} Nome: {insegnante.Nome} Cognome: {insegnante.Cognome} Classe: {insegnante.NomeClasse} Materia: {insegnante.NomeMateria}");
            }
        }

        static void AggiungiInsegnante()
        {
            Console.WriteLine("=== Aggiungi Insegnante ===");
            Console.Write("Inserisci l'ID dell'insegnante: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Inserisci il nome dell'insegnante: ");
            string nome = Console.ReadLine();
            Console.Write("Inserisci il cognome dell'insegnante: ");
            string cognome = Console.ReadLine();
            Console.Write("Inserisci il nome della classe assegnata: ");
            string nomeClasse = Console.ReadLine();
            Console.Write("Inserisci il nome della materia assegnata: ");
            string nomeMateria = Console.ReadLine();
            Console.Write("Inserisci l'ID della materia: ");
            int idMateria = int.Parse(Console.ReadLine());

            Insegnante nuovoInsegnante = new Insegnante(id, nome, cognome, nomeClasse, nomeMateria, idMateria);
            insegnanti.Add(nuovoInsegnante);

            Console.WriteLine("Insegnante aggiunto con successo.");
        }

        static void ModificaInsegnante()
        {
            Console.WriteLine("=== Modifica Insegnante ===");
            Console.Write("Inserisci l'ID dell'insegnante da modificare: ");
            int id = int.Parse(Console.ReadLine());

            Insegnante insegnanteDaModificare = insegnanti.Find(i => i.IDInsegnante == id);
            if (insegnanteDaModificare != null)
            {
                Console.Write("Inserisci il nuovo nome dell'insegnante: ");
                string nome = Console.ReadLine();
                Console.Write("Inserisci il nuovo cognome dell'insegnante: ");
                string cognome = Console.ReadLine();
                Console.Write("Inserisci la nuova classe assegnata: ");
                string nomeClasse = Console.ReadLine();
                Console.Write("Inserisci la nuova materia: ");
                string nomeMateria = Console.ReadLine();
                Console.Write("Inserisci il nuovo ID della materia: ");
                int idMateria = int.Parse(Console.ReadLine());

                insegnanteDaModificare.Nome = nome;
                insegnanteDaModificare.Cognome = cognome;
                insegnanteDaModificare.NomeClasse = nomeClasse;
                insegnanteDaModificare.NomeMateria = nomeMateria;
                insegnanteDaModificare.IDMateria = idMateria;

                Console.WriteLine("Insegnante modificato con successo.");
            }
            else
            {
                Console.WriteLine("Insegnante non trovato.");
            }
        }

        static void CancellaInsegnante()
        {
            Console.WriteLine("=== Cancella Insegnante ===");
            Console.Write("Inserisci l'ID dell'insegnante da cancellare: ");
            int id = int.Parse(Console.ReadLine());

            Insegnante insegnanteDaCancellare = insegnanti.Find(i => i.IDInsegnante == id);
            if (insegnanteDaCancellare != null)
            {
                insegnanti.Remove(insegnanteDaCancellare);
                Console.WriteLine("Insegnante cancellato con successo.");
            }
            else
            {
                Console.WriteLine("Insegnante non trovato.");
            }
        }

        static void ManageValutazioni()
        {
            Console.WriteLine("=== Gestione Valutazioni ===");
            Console.WriteLine("1. Visualizza Voto");
            Console.WriteLine("2. Aggiungi Voto");
            Console.WriteLine("3. Modifica Voto");
            Console.WriteLine("4. Cancella Voto");
            Console.WriteLine("===========================");

            Console.Write("Seleziona un'opzione: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    VisualizzaVoto();
                    break;
                case "2":
                    AggiungiVoto();
                    break;
                case "3":
                    ModificaVoto();
                    break;
                case "4":
                    CancellaVoto();
                    break;
                default:
                    Console.WriteLine("Opzione non valida. Riprova.");
                    break;
            }
        }

        static void VisualizzaVoto()
        {
            Console.WriteLine("=== Valutazioni Disponibili ===");
            foreach (var valutazione in valutazioni)
            {
                Console.WriteLine($"ID: {valutazione.IDValutazione} Voto: {valutazione.Voto} Media: {valutazione.Media} ID-Materia: {valutazione.IDMateria} ID-Studente: {valutazione.IDStudente}");
            }
        }

        static void AggiungiVoto()
        {
            Console.WriteLine("=== Aggiungi Voto ===");
            Console.Write("Inserisci l'ID dello studente: ");
            int idStudente = int.Parse(Console.ReadLine());
            Console.Write("Inserisci l'ID della materia: ");
            int idMateria = int.Parse(Console.ReadLine());
            Console.Write("Inserisci il voto: ");
            float voto = float.Parse(Console.ReadLine());

            // Calcola la media aggiornata
            float media = CalcolaMedia(idStudente, idMateria, voto);

            Valutazione nuovaValutazione = new Valutazione(valutazioni.Count + 1, voto, media, idMateria, idStudente);
            valutazioni.Add(nuovaValutazione);

            Console.WriteLine("Voto aggiunto con successo.");
        }

        static void ModificaVoto()
        {
            Console.WriteLine("=== Modifica Voto ===");
            Console.Write("Inserisci l'ID del voto da modificare: ");
            int idVoto = int.Parse(Console.ReadLine());

            Valutazione votoDaModificare = valutazioni.Find(v => v.IDValutazione == idVoto);
            if (votoDaModificare != null)
            {
                Console.Write("Inserisci il nuovo voto: ");
                float nuovoVoto = float.Parse(Console.ReadLine());

                // Calcola la media aggiornata
                float media = CalcolaMedia(votoDaModificare.IDStudente, votoDaModificare.IDMateria, nuovoVoto);

                votoDaModificare.Voto = nuovoVoto;
                votoDaModificare.Media = media;

                Console.WriteLine("Voto modificato con successo.");
            }
            else
            {
                Console.WriteLine("Voto non trovato.");
            }
        }

        static void CancellaVoto()
        {
            Console.WriteLine("=== Cancella Voto ===");
            Console.Write("Inserisci l'ID del voto da cancellare: ");
            int idVoto = int.Parse(Console.ReadLine());

            Valutazione votoDaCancellare = valutazioni.Find(v => v.IDValutazione == idVoto);
            if (votoDaCancellare != null)
            {
                valutazioni.Remove(votoDaCancellare);

                // Ricalcola la media dopo la cancellazione del voto
                float media = CalcolaMedia(votoDaCancellare.IDStudente, votoDaCancellare.IDMateria);

                // Aggiorna la media in tutte le valutazioni dello studente e materia
                AggiornaMedia(votoDaCancellare.IDStudente, votoDaCancellare.IDMateria, media);

                Console.WriteLine("Voto cancellato con successo.");
            }
            else
            {
                Console.WriteLine("Voto non trovato.");
            }
        }

        static float CalcolaMedia(int idStudente, int idMateria, float nuovoVoto = 0)
        {
            float sommaVoti = 0;
            int numeroValutazioni = 0;

            foreach (var valutazione in valutazioni)
            {
                if (valutazione.IDStudente == idStudente && valutazione.IDMateria == idMateria)
                {
                    if (valutazione.IDValutazione != valutazioni.Count + 1)
                    {
                        sommaVoti += valutazione.Voto;
                        numeroValutazioni++;
                    }
                    else
                    {
                        sommaVoti += nuovoVoto;
                        numeroValutazioni++;
                    }
                }
            }

            if (numeroValutazioni > 0)
                return sommaVoti / numeroValutazioni;

            return 0;
        }

        static void AggiornaMedia(int idStudente, int idMateria, float nuovaMedia)
        {
            foreach (var valutazione in valutazioni)
            {
                if (valutazione.IDStudente == idStudente && valutazione.IDMateria == idMateria)
                {
                    valutazione.Media = nuovaMedia;
                }
            }
        }

        static void LoadDataFromFile()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(';');

                        if (parts[0] == "Classe")
                        {
                            int id = int.Parse(parts[1]);
                            string nome = parts[2];

                            Classe classe = new Classe(id, nome);
                            classi.Add(classe);
                        }
                        else if (parts[0] == "Studente")
                        {
                            int id = int.Parse(parts[1]);
                            string nome = parts[2];
                            string cognome = parts[3];
                            DateOnly dataNascita = DateOnly.Parse(parts[4]);
                            int annoCorso = int.Parse(parts[5]);
                            string nomeClasse = parts[6];

                            Studente studente = new Studente(id, nome, cognome, dataNascita, annoCorso, nomeClasse);
                            studenti.Add(studente);
                        }
                        else if (parts[0] == "Insegnante")
                        {
                            int id = int.Parse(parts[1]);
                            string nome = parts[2];
                            string cognome = parts[3];
                            string nomeClasse = parts[4];
                            string nomeMateria = parts[5];
                            int idMateria = int.Parse(parts[6]);

                            Insegnante insegnante = new Insegnante(id, nome, cognome, nomeClasse, nomeMateria, idMateria);
                            insegnanti.Add(insegnante);
                        }
                        else if (parts[0] == "Valutazione")
                        {
                            int id = int.Parse(parts[1]);
                            float voto = float.Parse(parts[2]);
                            float media = float.Parse(parts[3]);
                            int idMateria = int.Parse(parts[4]);
                            int idStudente = int.Parse(parts[5]);

                            Valutazione valutazione = new Valutazione(id, voto, media, idMateria, idStudente);
                            valutazioni.Add(valutazione);
                        }
                    }

                    Console.WriteLine("Dati caricati con successo.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Si è verificato un errore durante il caricamento dei dati: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("Il file dei dati non esiste. Verrà creato un nuovo file durante il salvataggio dei dati.");
            }
        }

        static void SaveDataToFile()
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (var classe in classi)
                {
                    string line = $"Classe;{classe.IDClasse};{classe.NomeClasse};";
                    lines.Add(line);
                }

                foreach (var studente in studenti)
                {
                    string line = $"Studente;{studente.IDStudente};{studente.Nome};{studente.Cognome};{studente.DataNascita};{studente.AnnoCorso};{studente.NomeClasse}";
                    lines.Add(line);
                }

                foreach (var insegnante in insegnanti)
                {
                    string line = $"Insegnante;{insegnante.IDInsegnante};{insegnante.Nome};{insegnante.Cognome};{insegnante.NomeClasse};{insegnante.NomeMateria};{insegnante.IDMateria}";
                    lines.Add(line);
                }

                foreach (var valutazione in valutazioni)
                {
                    string line = $"Valutazione;{valutazione.IDValutazione};{valutazione.Voto};{valutazione.Media};{valutazione.IDMateria};{valutazione.IDStudente}";
                    lines.Add(line);
                }

                File.WriteAllLines(filePath, lines);

                Console.WriteLine("Dati salvati con successo.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Si è verificato un errore durante il salvataggio dei dati: " + e.Message);
            }
        }
    }
}