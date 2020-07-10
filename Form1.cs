using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime;

namespace ProduitsPerimes
{
    public partial class Form : System.Windows.Forms.Form
    {
        delegate void CreationFichier(string S_path, ref List<Entree> data);
        bool usermodifindic = false;
        bool OuvertDepuisFichier = false;
        string OuvertDepuisPath = "";
        public string Separateur = ";";
        public string[] NomsChamps = new string[6] { "Produit", "Quantite", "PrixHT", "PrixVente", "EquivalentHT", "EquivalentVente" };
        public string PathOuverture = "";
        public string PathSauvegarde = "";
        public int entrees = 0;
        public int produits = 0;
        public List<Entree> EntreesUtilisateur = new List<Entree>();
        public List<Entree> Base = new List<Entree>();
        public Form()
        {
            InitializeComponent();
            indicateur.Text = "";
            Annuler.Enabled = false;
            ChargerDernierChemin();
        }


        private string StrEntree(Entree Input)
        {

            string p1;
            string p2;
            string E1;
            string E2;
            if (Input.RemplaHT)
            {
                E1 = (Input.PrixHT * Input.Qte).ToString();
                p1 = Input.PrixHT.ToString();
            }
            else
            {
                E1 = "-";
                p1 = "-";
            }
            if (Input.RemplaVente)
            {
                E2 = (Input.PrixVente * Input.Qte).ToString();
                p2 = Input.PrixVente.ToString();
            }
            else
            {
                E2 = "-";
                p2 = "-";
            }
            string outp = Input.Prod + Separateur + Input.Qte + Separateur + p1 + Separateur + p2 + Separateur + E1 + Separateur + E2;
            return outp;
        }
        private void ConstruireBilan(ref List<Entree> Bilan)
        {
            List<int> Modif = new List<int>();
            for (int i = 0; i < EntreesUtilisateur.Count; i++)
            {
                Entree E1 = EntreesUtilisateur.ElementAt(i);
                bool Found = false;
                for (int j = 0; j < Base.Count; j++)
                {
                    Entree E2 = Base.ElementAt(j);
                    if (E1.Prod == E2.Prod)
                    {
                        Found = true;
                        Modif.Add(j);
                        float PH = E2.PrixHT;
                        float PV = E2.PrixVente;
                        if (E1.RemplaHT)
                        {
                            PH = E1.PrixHT;
                        }
                        if (E1.RemplaVente)
                        {
                            PV = E1.PrixVente;
                        }
                        Entree E = new Entree(E1.Prod, (E1.Qte + E2.Qte).ToString(), PH.ToString(), PV.ToString(), true, true);
                        Bilan.Add(E);
                    }
                }
                if (!Found)
                {
                    Bilan.Add(E1);
                }
            }
            for (int j = 0; j < Base.Count; j++)
            {
                if (!Modif.Contains(j))
                {
                    Bilan.Add(Base.ElementAt(j));
                }
            }
        }
        private bool ChaineContenue(string A, string B)
        {
            if (B.Length > A.Length)
            {
                return false;
            }
            if (A == B)
            {
                return true;
            }
            bool OK = false;
            for (int i = 0; i <= A.Length - B.Length; i++)
            {
                if (B == A.Substring(i, B.Length))
                {
                    OK = true;
                    break;
                }
            }
            return OK;
        }

        private void Parcourir_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            Parcourir_();
            this.ResumeLayout();

        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            Ajouter_();
        }

        private void Sauver_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            if (!(ProduitsPossibles.Text == "" && QTE.Text == "" && PrxHt.Text == "" && PrxVte.Text == ""))
            {
                var res = MessageBox.Show(this, "Un article n'a pas été ajouté, voulez vous sauvegarder quand même ?", "Attention !",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    CalcEtSauver_();
                }
            }
            else
            {
                CalcEtSauver_();
            }

            this.ResumeLayout();
        }

        private void Perimés_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SuspendLayout();
            if (EntreesUtilisateur.Count != 0)
            {
                var res = MessageBox.Show(this, "Vous n'avez pas sauvegardé, voulez vous quitter ?", "Attention !",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (res != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }
            this.ResumeLayout();
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            if (EntreesUtilisateur.Count != 0)
            {
                entrees -= 1;
                produits -= EntreesUtilisateur.Last().Qte;
                Entrees.Text = "Entrées : " + entrees;
                Nproduits.Text = "Nombre d'articles : " + produits;
                EntreesUtilisateur.RemoveAt(EntreesUtilisateur.Count - 1);
            }
            if (EntreesUtilisateur.Count == 0)
            {
                Annuler.Enabled = false;
            }

        }

        private void Charger_Click(object sender, EventArgs e)
        {
            Charger_();

        }
        private void ProduitsPossibles_Click(object sender, EventArgs e)
        {
            ProduitsPossibles.DroppedDown = true;
        }

        private void ProduitsPossibles_TextChanged(object sender, EventArgs e)
        {
            if (!(ProduitsPossibles.Text == "" && QTE.Text == "" && PrxHt.Text == "" && PrxVte.Text == ""))
            {
                indicateur.Text = "Produit Non Ajouté";
            }
            else
            {
                indicateur.Text = "";
            }
            if (usermodifindic)
            {
                if (ProduitsPossibles.DroppedDown)
                {
                    RefreshBox();
                }
            }
        }
        private void DT_TextChanged(object sender, EventArgs e)
        {
            if (!(ProduitsPossibles.Text == "" && QTE.Text == "" && PrxHt.Text == "" && PrxVte.Text == ""))
            {
                indicateur.Text = "Produit Non Ajouté";
            }
            else
            {
                indicateur.Text = "";
            }
        }

        private void ProduitsPossibles_DropDown(object sender, EventArgs e)
        {
            RefreshBox();
        }
        private void ProduitsPossibles_key(object sender, EventArgs e)
        {
            usermodifindic = true;
        }
        private void RefreshBox()
        {
            int selector = ProduitsPossibles.SelectionStart;

            List<string> PP = new List<string>();
            string sel = ProduitsPossibles.Text;
            string prod = "";
            for (int i = 0; i < EntreesUtilisateur.Count; i++)
            {
                prod = EntreesUtilisateur.ElementAt(i).Prod;
                if (ChaineContenue(prod, sel.ToUpper()) && !PP.Contains(prod))
                {
                    PP.Add(prod);
                }
            }
            for (int i = 0; i < Base.Count; i++)
            {
                prod = Base.ElementAt(i).Prod;
                if (ChaineContenue(prod, sel.ToUpper()) && !PP.Contains(prod))
                {
                    PP.Add(prod);
                }
            }
            ProduitsPossibles.Items.Clear();
            ProduitsPossibles.Items.Add(sel);
            PP.Sort();
            for (int i = 0; i < PP.Count; i++)
            {
                ProduitsPossibles.Items.Add(PP.ElementAt(i));
            }
            ProduitsPossibles.Select(ProduitsPossibles.Text.Length, selector);
            usermodifindic = false;
        }
        private void SauverEtHistorique(ref List<Entree> Bilan, string Path)
        {
            Create(Path, ref Bilan);
            if (ModifsSave.Checked)
            {
                string dateHeure = DateTime.Now.ToString().Replace('/', 'I').Replace(' ', '_').Replace(':', '-');
                string HistoryPath = System.IO.Directory.GetParent(Path) + "/Historique_" + nomFichier_.Text;
                string SubHistory = HistoryPath + "/" + dateHeure;
                if (!System.IO.Directory.Exists(HistoryPath))
                {
                    System.IO.Directory.CreateDirectory(HistoryPath);
                }
                if (!System.IO.Directory.Exists(SubHistory))
                {
                    System.IO.Directory.CreateDirectory(SubHistory);
                }
                string path = SubHistory + "/AjoutsDu_" + dateHeure + "I";
                Create(path, ref EntreesUtilisateur);
            }
        }
        private void CreateXLS(string S_path, ref List<Entree> data)
        {
            if (System.IO.File.Exists(S_path))
            {
                System.IO.File.Delete(S_path);
            }
            //generer xls
            Excel.Application oApp = new Excel.Application();
            Excel.Workbook oBook = oApp.Workbooks.Add();
            Excel.Worksheet oSheet = (Excel.Worksheet)oBook.Worksheets.get_Item(1);
            for (int i = 1; i <= 6; i++)
            {
                oSheet.Cells[1, i] = NomsChamps[i - 1];
            }
            for (int i = 2; i < data.Count + 2; i++)
            {
                Entree e = data.ElementAt(i - 2);
                oSheet.Cells[i, 1] = e.Prod;
                oSheet.Cells[i, 2] = e.Qte.ToString();
                oSheet.Cells[i, 3] = e.PrixHT.ToString();
                oSheet.Cells[i, 4] = e.PrixVente.ToString();
                oSheet.Cells[i, 5] = "=B" + (i).ToString() + "*C" + (i).ToString();
                oSheet.Cells[i, 6] = "=B" + (i).ToString() + "*D" + (i).ToString();
            }
            oBook.SaveAs(S_path);
            oBook.Close();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
            oApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oApp);
        }
        private void CreateTxt(string S_path, ref List<Entree> data)
        {
            if (System.IO.File.Exists(S_path))
            {
                System.IO.File.Delete(S_path);
            }
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(S_path))
            {
                file.WriteLine(NomsChamps[0] + Separateur + NomsChamps[1] + Separateur + NomsChamps[2] + Separateur + NomsChamps[3] + Separateur + NomsChamps[4] + Separateur + NomsChamps[5]);
                for (int i = 0; i < data.Count; i++)
                {
                    file.WriteLine(StrEntree(data.ElementAt(i)));
                }
            }
        }
        private void CreateBin(string path, ref List<Entree> Bilan)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.Stream stream = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None);
            formatter.Serialize(stream, Bilan);
            stream.Close();
        }
        private List<Entree> ReadInXls(string S_path)
        {
            List<Entree> retour = new List<Entree>();
            Entree e;
            Excel.Application oApp = new Excel.Application();
            Excel.Workbook oBook = oApp.Workbooks.Open(@S_path);
            Excel.Worksheet oSheet = oBook.Sheets[1];
            Excel.Range oRange = oSheet.UsedRange;
            string Pn = "";
            int i = 1;
            while (oRange.Cells[i, 1] != null && oRange.Cells[i, 1].Value2 != null)
            {
                i++;
                if (oRange.Cells[i, 1] != null && oRange.Cells[i, 1].Value2 != null)
                {
                    Pn = (string)oRange.Cells[i, 1].Value2.ToString();
                    e = new Entree(Pn, (string)oRange.Cells[i, 2].Value2.ToString(), (string)oRange.Cells[i, 3].Value2.ToString(), (string)oRange.Cells[i, 4].Value2.ToString(), true, true);
                    retour.Add(e);
                }
                else
                {
                    break;
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRange);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
            oBook.Close();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
            oApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oApp);
            return retour;
        }
        private List<Entree> ReadInTxt(string S_path)
        {
            string[] lines = System.IO.File.ReadAllLines(@S_path);
            List<Entree> sortie = new List<Entree>();
            Entree e;
            for (int i = 1; i < lines.Count(); i++)
            {

                string[] decomp = new string[4];
                int ch = 0;
                string line = lines[i];
                for (int j = 0; j < 4; j++)
                {

                    string sub = "";
                    while (ch < line.Length && line[ch].ToString() != Separateur)
                    {
                        sub += line[ch];
                        ch++;
                    }
                    decomp[j] = sub;
                    ch++;
                }
                e = new Entree(decomp[0], decomp[1], decomp[2], decomp[3], true, true);
                sortie.Add(e);
            }
            return sortie;
        }
        private List<Entree> ReadInBin(string S_path)
        {
            string path = S_path;
            if (!System.IO.File.Exists(path))
            {
                return new List<Entree>();
            }
            List<Entree> Out = new List<Entree>();
            if (System.IO.File.Exists(path))
            {
                System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                System.IO.Stream stream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                Out = (List<Entree>)formatter.Deserialize(stream);
                stream.Close();

            }
            return Out;
        }
        private List<Entree> Read(string S_path)
        {
            if (S_path.Substring(S_path.Length - 4, 4) == "xlsx")
            {
                return ReadInXls(S_path);
            }
            else if (S_path.Substring(S_path.Length - 3, 3) == "txt")
            {
                return ReadInTxt(S_path);
            }
            else
            {
                return ReadInBin(S_path);
            }
        }
        private void Create(string S_path, ref List<Entree> data)
        {
            CreationFichier Typef;
            if (Xls.Checked)
            {
                if (!System.IO.File.Exists(S_path + ".xlsx"))
                {
                    CreateXLS(S_path + ".xlsx", ref data);
                }
                else
                {
                    Typef = new CreationFichier(CreateXLS);
                    ReplaceFile(Typef, S_path + ".xlsx", ref data);
                }
            }
            else
            {
                if (System.IO.File.Exists(S_path + ".xlsx"))
                {
                    System.IO.File.Delete(S_path + ".xlsx");
                }
            }
            if (Txt.Checked)
            {
                if (!System.IO.File.Exists(S_path + ".txt"))
                {
                    CreateTxt(S_path + ".txt", ref data);
                }
                else
                {
                    Typef = new CreationFichier(CreateTxt);
                    ReplaceFile(Typef, S_path + ".txt", ref data);
                }
            }
            else
            {
                if (System.IO.File.Exists(S_path + ".txt"))
                {
                    System.IO.File.Delete(S_path + ".txt");
                }
            }
            if (Bin.Checked)
            {
                if (!System.IO.File.Exists(S_path + ".bin"))
                {
                    CreateBin(S_path + ".bin", ref data);
                }
                else
                {
                    Typef = new CreationFichier(CreateBin);
                    ReplaceFile(Typef, S_path + ".bin", ref data);
                }
            }
            else
            {
                if (System.IO.File.Exists(S_path + ".bin"))
                {
                    System.IO.File.Delete(S_path + ".bin");
                }
            }
        }
        private void CalcEtSauver_()
        {
            if (!Bin.Checked && !Txt.Checked && !Xls.Checked)
            {
                MessageBox.Show("Veuillez selectionner un type de fichier (xls,txt ou bin)");
            }
            else
            {
                if (PathSauvegarde == "" || PathSauvegarde == null || nomFichier_.Text == "")
                {
                    MessageBox.Show("Veuillez choisir un repertoire de sauvegarde à l'aide du bouton [...] et specifier un nom de fichier");
                }
                else
                {
                    if (CanSave(PathSauvegarde + "/" + nomFichier_.Text))
                    {
                        List<Entree> Bilan = new List<Entree>();
                        ConstruireBilan(ref Bilan);
                        SauverEtHistorique(ref Bilan, PathSauvegarde + "/" + nomFichier_.Text);
                        Base = Bilan;
                        MessageBox.Show("Modifications Enregistrees");
                        EntreesUtilisateur = new List<Entree>();
                        entrees = 0;
                        produits = 0;
                        Entrees.Text = "Entrées : " + entrees;
                        Nproduits.Text = "Nombre d'articles : " + produits;
                        SauverDernierChemin(PathSauvegarde + "/" + nomFichier_.Text);
                        OuvertDepuisFichier = true;
                        OuvertDepuisPath = PathSauvegarde + "/" + nomFichier_.Text;
                        Annuler.Enabled = false;
                    }
                }
            }
        }
        private void Ouvrir_()
        {
            Base = Read(PathOuverture);
            OuvertDepuisFichier = true;
            OuvertDepuisPath = PathOuverture;
        }
        private void Ajouter_()
        {
            bool rplHT = true;
            bool rplVT = true;
            if (PrxHt.Text == "")
            {
                rplHT = false;
            }
            if (PrxVte.Text == "")
            {
                rplVT = false;
            }
            Entree E = new Entree(ProduitsPossibles.Text, QTE.Text, PrxHt.Text, PrxVte.Text, rplHT, rplVT);
            produits += E.Qte;
            entrees++;
            Entrees.Text = "Entrées : " + entrees;
            Nproduits.Text = "Nombre d'articles : " + produits;
            for (int i = EntreesUtilisateur.Count - 1; i >= 0; i--)
            {
                Entree K = EntreesUtilisateur.ElementAt(i);
                if (E.Prod == K.Prod)
                {
                    E.Qte += K.Qte;
                    if (!E.RemplaHT)
                    {
                        E.PrixHT = K.PrixHT;
                    }
                    if (E.RemplaVente)
                    {
                        E.PrixVente = K.PrixVente;
                    }
                    EntreesUtilisateur.RemoveAt(i);
                    goto Finish;
                }
            }
            Finish:
            EntreesUtilisateur.Add(E);
            ProduitsPossibles.Text = "";
            QTE.Text = "";
            PrxHt.Text = "";
            PrxVte.Text = "";
            indicateur.Text = "";
            Annuler.Enabled = true;
        }
        private void Charger_()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Fichier Texte|*.txt|Fichier Binaire|*.bin|Feuille Excel|*.xlsx";
            string txt = "";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                txt = ofd.FileName;
                nomFichier_.Text = System.IO.Path.GetFileNameWithoutExtension(txt);
                PathSauvegarde = System.IO.Directory.GetParent(txt).ToString();
                Chemin.Text = "Repertoire : " + PathSauvegarde;
                PathOuverture = txt;
                Ouvrir_();
                MessageBox.Show("Fichiers Chargés");
            }

        }
        private void Parcourir_()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                PathSauvegarde = fbd.SelectedPath;
                Chemin.Text = "Repertoire : " + PathSauvegarde;
            }
        }
        private string CheminExe()
        {
            return System.IO.Directory.GetParent(System.Reflection.Assembly.GetEntryAssembly().Location).ToString() + "/";
        }
        private void SauverDernierChemin(string ToSave)
        {
            //Sauver au bon endroit le dernier chemin
            string ext;
            if (Bin.Checked)
            {
                ext = ".bin";
            }
            else if (Txt.Checked)
            {
                ext = ".txt";
            }
            else
            {
                ext = ".xlsx";
            }
            string pth = CheminExe() + "Last.txt";
            if (System.IO.File.Exists(pth))
            {
                System.IO.File.Delete(pth);
            }
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(pth))
            {
                file.WriteLine(ToSave + ext);
            }
        }
        private void ChargerDernierChemin()
        {
            string pth = CheminExe() + "Last.txt";
            if (System.IO.File.Exists(pth))
            {
                string[] lines = System.IO.File.ReadAllLines(@pth);
                string PT = lines[0];
                //Charger dans pt le dernier chemin contenu dans pth
                if (System.IO.File.Exists(PT))
                {
                    PathSauvegarde = System.IO.Directory.GetParent(PT).ToString();
                    nomFichier_.Text = System.IO.Path.GetFileNameWithoutExtension(PT);
                    Chemin.Text = "Repertoire : " + PathSauvegarde;
                    PathOuverture = PT;
                    Ouvrir_();
                }
            }
        }
        private bool CanSave(string Path)
        {
            if ((System.IO.File.Exists(Path + ".txt") || System.IO.File.Exists(Path + ".bin") || System.IO.File.Exists(Path + ".xlsx")))
            {
                if (OuvertDepuisFichier)
                {
                    string pr = System.IO.Directory.GetParent(OuvertDepuisPath).ToString();
                    if (!((nomFichier_.Text == System.IO.Path.GetFileNameWithoutExtension(OuvertDepuisPath)) && pr == PathSauvegarde))
                    {
                        //Si le fichier de sauvegarde existe deja et qu'il est different de celui depuis lequel le fichier a ete ouvert
                        bool r = MessageRemplacerFichier(Path);
                        if (r)
                        {
                            DeleteFileName(Path);
                        }
                        return r;
                    }
                }
                else
                {
                    //Si le fichier de destination existe et que l'on crée un nouveau fichier
                    bool r = MessageRemplacerFichier(Path);
                    if (r)
                    {
                        DeleteFileName(Path);
                    }
                    return r;
                }
            }
            return true;
        }
        private bool MessageRemplacerFichier(string Path)
        {
            var res = MessageBox.Show(this, "Voulez vous remplacer la base de donnée " + nomFichier_.Text + " ?", "Attention !",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            return res == DialogResult.Yes;

        }
        private void DeleteFileName(string Path)
        {
            if (System.IO.File.Exists(Path + ".txt"))
            {
                System.IO.File.Delete(Path + ".txt");
            }
            if (System.IO.File.Exists(Path + ".bin"))
            {
                System.IO.File.Delete(Path + ".bin");
            }
            if (System.IO.File.Exists(Path + ".xlsx"))
            {
                System.IO.File.Delete(Path + ".xlsx");
            }
        }
        private void ReplaceFile(CreationFichier FileCreation, string path, ref List<Entree> data)
        {
            string TmpPath = System.IO.Path.GetTempFileName();
            FileCreation(TmpPath, ref data);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            System.IO.File.Move(TmpPath, path);
        }
        [Serializable]
        public class Entree
        {
            public string Prod;
            public int Qte;
            public float PrixHT;
            public float PrixVente;
            public bool RemplaHT;
            public bool RemplaVente;
            public Entree(string Pr, string Qt, string Ph, string Pv, bool Rh, bool Rv)
            {
                Prod = Pr.ToUpper();
                try
                {
                    Qte = Convert.ToInt32(Qt);
                }
                catch (FormatException e)
                {
                    Qte = 1;
                    e.ToString();
                }
                try
                {
                    PrixHT = Convert.ToSingle(Ph.Replace('.', ','));
                }
                catch (FormatException e)
                {
                    PrixHT = 0;
                    e.ToString();
                }
                try
                {
                    PrixVente = Convert.ToSingle(Pv.Replace('.', ','));
                }
                catch (FormatException e)
                {
                    PrixVente = 0;
                    e.ToString();
                }
                RemplaHT = Rh;
                RemplaVente = Rv;
            }
        }

        private void neww_Click(object sender, EventArgs e)
        {
            if (EntreesUtilisateur.Count != 0)
            {
                var res = MessageBox.Show(this, "Des articles n'ont pas etes sauvegardés, voulez vous les conserver ?", "Attention !",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (res != DialogResult.No)
                {
                    EntreesUtilisateur = new List<Entree>();
                    entrees = 0;
                    produits = 0;
                    Entrees.Text = "Entrées : " + entrees;
                    Nproduits.Text = "Nombre d'articles : " + produits;
                    Annuler.Enabled = false;
                }
                
            }
            Base = new List<Entree>();
            if (PathSauvegarde == "" || PathSauvegarde == null)
            {

                PathSauvegarde = CheminExe() + "saves_default_";
            }
            nomFichier_.Text = System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetRandomFileName());
            OuvertDepuisPath = PathSauvegarde + "/" + nomFichier_.Text;
            SauverDernierChemin(PathSauvegarde + "/" + nomFichier_.Text);
            OuvertDepuisFichier = true;
        }
    }
}
