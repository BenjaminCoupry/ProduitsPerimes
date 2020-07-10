namespace ProduitsPerimes
{
    partial class Form
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.Parcourir = new System.Windows.Forms.Button();
            this.Sauver = new System.Windows.Forms.Button();
            this.Entrees = new System.Windows.Forms.Label();
            this.Nproduits = new System.Windows.Forms.Label();
            this.Ajouter = new System.Windows.Forms.Button();
            this.QTE = new System.Windows.Forms.TextBox();
            this.PrxHt = new System.Windows.Forms.TextBox();
            this.PrxVte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ModifsSave = new System.Windows.Forms.CheckBox();
            this.Chemin = new System.Windows.Forms.Label();
            this.Annuler = new System.Windows.Forms.Button();
            this.ProduitsPossibles = new System.Windows.Forms.ComboBox();
            this.indicateur = new System.Windows.Forms.Label();
            this.copyr = new System.Windows.Forms.Label();
            this.Xls = new System.Windows.Forms.CheckBox();
            this.Txt = new System.Windows.Forms.CheckBox();
            this.Bin = new System.Windows.Forms.CheckBox();
            this.Charger = new System.Windows.Forms.Button();
            this.nomFichier_ = new System.Windows.Forms.TextBox();
            this.NomFichier = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.neww = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Parcourir
            // 
            this.Parcourir.Location = new System.Drawing.Point(522, 301);
            this.Parcourir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Parcourir.Name = "Parcourir";
            this.Parcourir.Size = new System.Drawing.Size(44, 26);
            this.Parcourir.TabIndex = 0;
            this.Parcourir.Text = "...";
            this.Parcourir.UseVisualStyleBackColor = true;
            this.Parcourir.Click += new System.EventHandler(this.Parcourir_Click);
            // 
            // Sauver
            // 
            this.Sauver.Location = new System.Drawing.Point(495, 273);
            this.Sauver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Sauver.Name = "Sauver";
            this.Sauver.Size = new System.Drawing.Size(94, 26);
            this.Sauver.TabIndex = 2;
            this.Sauver.Text = "Sauvegarder";
            this.Sauver.UseVisualStyleBackColor = true;
            this.Sauver.Click += new System.EventHandler(this.Sauver_Click);
            // 
            // Entrees
            // 
            this.Entrees.AutoSize = true;
            this.Entrees.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Entrees.Location = new System.Drawing.Point(11, 284);
            this.Entrees.Name = "Entrees";
            this.Entrees.Size = new System.Drawing.Size(53, 15);
            this.Entrees.TabIndex = 3;
            this.Entrees.Text = "Entrées :";
            // 
            // Nproduits
            // 
            this.Nproduits.AutoSize = true;
            this.Nproduits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nproduits.Location = new System.Drawing.Point(11, 307);
            this.Nproduits.Name = "Nproduits";
            this.Nproduits.Size = new System.Drawing.Size(110, 15);
            this.Nproduits.TabIndex = 4;
            this.Nproduits.Text = "Nombre d\'articles :";
            // 
            // Ajouter
            // 
            this.Ajouter.Location = new System.Drawing.Point(656, 35);
            this.Ajouter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Ajouter.Name = "Ajouter";
            this.Ajouter.Size = new System.Drawing.Size(87, 26);
            this.Ajouter.TabIndex = 5;
            this.Ajouter.Text = "Ajouter";
            this.Ajouter.UseVisualStyleBackColor = true;
            this.Ajouter.Click += new System.EventHandler(this.Ajouter_Click);
            // 
            // QTE
            // 
            this.QTE.Location = new System.Drawing.Point(285, 38);
            this.QTE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QTE.Name = "QTE";
            this.QTE.Size = new System.Drawing.Size(116, 23);
            this.QTE.TabIndex = 7;
            this.QTE.TextChanged += new System.EventHandler(this.DT_TextChanged);
            // 
            // PrxHt
            // 
            this.PrxHt.Location = new System.Drawing.Point(409, 38);
            this.PrxHt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PrxHt.Name = "PrxHt";
            this.PrxHt.Size = new System.Drawing.Size(116, 23);
            this.PrxHt.TabIndex = 8;
            this.PrxHt.TextChanged += new System.EventHandler(this.DT_TextChanged);
            // 
            // PrxVte
            // 
            this.PrxVte.Location = new System.Drawing.Point(532, 38);
            this.PrxVte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PrxVte.Name = "PrxVte";
            this.PrxVte.Size = new System.Drawing.Size(116, 23);
            this.PrxVte.TabIndex = 9;
            this.PrxVte.TextChanged += new System.EventHandler(this.DT_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Produit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Quantité";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Prix H.T";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(528, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Prix Vente";
            // 
            // ModifsSave
            // 
            this.ModifsSave.AutoSize = true;
            this.ModifsSave.Location = new System.Drawing.Point(633, 234);
            this.ModifsSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ModifsSave.Name = "ModifsSave";
            this.ModifsSave.Size = new System.Drawing.Size(116, 19);
            this.ModifsSave.TabIndex = 16;
            this.ModifsSave.Text = "Creer Historique";
            this.ModifsSave.UseVisualStyleBackColor = true;
            // 
            // Chemin
            // 
            this.Chemin.AutoSize = true;
            this.Chemin.Location = new System.Drawing.Point(572, 307);
            this.Chemin.Name = "Chemin";
            this.Chemin.Size = new System.Drawing.Size(143, 15);
            this.Chemin.TabIndex = 17;
            this.Chemin.Text = "Choisissez Un Repertoire";
            // 
            // Annuler
            // 
            this.Annuler.Location = new System.Drawing.Point(656, 69);
            this.Annuler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Annuler.Name = "Annuler";
            this.Annuler.Size = new System.Drawing.Size(87, 26);
            this.Annuler.TabIndex = 18;
            this.Annuler.Text = "Annuler";
            this.Annuler.UseVisualStyleBackColor = true;
            this.Annuler.Click += new System.EventHandler(this.Annuler_Click);
            // 
            // ProduitsPossibles
            // 
            this.ProduitsPossibles.FormattingEnabled = true;
            this.ProduitsPossibles.Location = new System.Drawing.Point(14, 38);
            this.ProduitsPossibles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ProduitsPossibles.Name = "ProduitsPossibles";
            this.ProduitsPossibles.Size = new System.Drawing.Size(265, 23);
            this.ProduitsPossibles.TabIndex = 19;
            this.ProduitsPossibles.DropDown += new System.EventHandler(this.ProduitsPossibles_DropDown);
            this.ProduitsPossibles.TextChanged += new System.EventHandler(this.ProduitsPossibles_TextChanged);
            this.ProduitsPossibles.Click += new System.EventHandler(this.ProduitsPossibles_Click);
            this.ProduitsPossibles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProduitsPossibles_key);
            // 
            // indicateur
            // 
            this.indicateur.AutoSize = true;
            this.indicateur.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indicateur.Location = new System.Drawing.Point(65, 19);
            this.indicateur.Name = "indicateur";
            this.indicateur.Size = new System.Drawing.Size(111, 15);
            this.indicateur.TabIndex = 20;
            this.indicateur.Text = "Produit Non Ajouté";
            // 
            // copyr
            // 
            this.copyr.AutoSize = true;
            this.copyr.Location = new System.Drawing.Point(14, 340);
            this.copyr.Name = "copyr";
            this.copyr.Size = new System.Drawing.Size(87, 15);
            this.copyr.TabIndex = 21;
            this.copyr.Text = "B.Coupry 2018";
            // 
            // Xls
            // 
            this.Xls.AutoSize = true;
            this.Xls.Checked = true;
            this.Xls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Xls.Location = new System.Drawing.Point(633, 207);
            this.Xls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Xls.Name = "Xls";
            this.Xls.Size = new System.Drawing.Size(126, 19);
            this.Xls.TabIndex = 22;
            this.Xls.Text = "Generer fichier xls";
            this.Xls.UseVisualStyleBackColor = true;
            // 
            // Txt
            // 
            this.Txt.AutoSize = true;
            this.Txt.Checked = true;
            this.Txt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Txt.Location = new System.Drawing.Point(633, 183);
            this.Txt.Name = "Txt";
            this.Txt.Size = new System.Drawing.Size(124, 19);
            this.Txt.TabIndex = 23;
            this.Txt.Text = "Generer fichier txt";
            this.Txt.UseVisualStyleBackColor = true;
            // 
            // Bin
            // 
            this.Bin.AutoSize = true;
            this.Bin.Checked = true;
            this.Bin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Bin.Location = new System.Drawing.Point(633, 160);
            this.Bin.Name = "Bin";
            this.Bin.Size = new System.Drawing.Size(128, 19);
            this.Bin.TabIndex = 24;
            this.Bin.Text = "Generer fichier bin";
            this.Bin.UseVisualStyleBackColor = true;
            // 
            // Charger
            // 
            this.Charger.Location = new System.Drawing.Point(385, 273);
            this.Charger.Name = "Charger";
            this.Charger.Size = new System.Drawing.Size(75, 24);
            this.Charger.TabIndex = 25;
            this.Charger.Text = "Charger";
            this.Charger.UseVisualStyleBackColor = true;
            this.Charger.Click += new System.EventHandler(this.Charger_Click);
            // 
            // nomFichier_
            // 
            this.nomFichier_.Location = new System.Drawing.Point(615, 334);
            this.nomFichier_.Name = "nomFichier_";
            this.nomFichier_.Size = new System.Drawing.Size(170, 23);
            this.nomFichier_.TabIndex = 26;
            this.nomFichier_.Text = "Nom_De_Fichier";
            // 
            // NomFichier
            // 
            this.NomFichier.AutoSize = true;
            this.NomFichier.Location = new System.Drawing.Point(522, 337);
            this.NomFichier.Name = "NomFichier";
            this.NomFichier.Size = new System.Drawing.Size(93, 15);
            this.NomFichier.TabIndex = 27;
            this.NomFichier.Text = "Nom du fichier :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(466, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "Ou";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(504, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 15);
            this.label6.TabIndex = 29;
            this.label6.Text = "|>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(504, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 15);
            this.label7.TabIndex = 30;
            this.label7.Text = "|>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(504, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 15);
            this.label8.TabIndex = 31;
            this.label8.Text = "|";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(627, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 15);
            this.label9.TabIndex = 32;
            this.label9.Text = "Parametres de sauvegarde :";
            // 
            // neww
            // 
            this.neww.Location = new System.Drawing.Point(385, 303);
            this.neww.Name = "neww";
            this.neww.Size = new System.Drawing.Size(75, 23);
            this.neww.TabIndex = 33;
            this.neww.Text = "Nouveau";
            this.neww.UseVisualStyleBackColor = true;
            this.neww.Click += new System.EventHandler(this.neww_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(803, 375);
            this.Controls.Add(this.neww);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NomFichier);
            this.Controls.Add(this.nomFichier_);
            this.Controls.Add(this.Charger);
            this.Controls.Add(this.Bin);
            this.Controls.Add(this.Txt);
            this.Controls.Add(this.Xls);
            this.Controls.Add(this.copyr);
            this.Controls.Add(this.indicateur);
            this.Controls.Add(this.ProduitsPossibles);
            this.Controls.Add(this.Annuler);
            this.Controls.Add(this.Chemin);
            this.Controls.Add(this.ModifsSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PrxVte);
            this.Controls.Add(this.PrxHt);
            this.Controls.Add(this.QTE);
            this.Controls.Add(this.Ajouter);
            this.Controls.Add(this.Nproduits);
            this.Controls.Add(this.Entrees);
            this.Controls.Add(this.Sauver);
            this.Controls.Add(this.Parcourir);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form";
            this.Text = "Perimés V1.7.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Perimés_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Parcourir;
        private System.Windows.Forms.Button Sauver;
        private System.Windows.Forms.Label Entrees;
        private System.Windows.Forms.Label Nproduits;
        private System.Windows.Forms.Button Ajouter;
        private System.Windows.Forms.TextBox QTE;
        private System.Windows.Forms.TextBox PrxHt;
        private System.Windows.Forms.TextBox PrxVte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ModifsSave;
        private System.Windows.Forms.Label Chemin;
        private System.Windows.Forms.Button Annuler;
        private System.Windows.Forms.ComboBox ProduitsPossibles;
        private System.Windows.Forms.Label indicateur;
        private System.Windows.Forms.Label copyr;
        private System.Windows.Forms.CheckBox Xls;
        private System.Windows.Forms.CheckBox Txt;
        private System.Windows.Forms.CheckBox Bin;
        private System.Windows.Forms.Button Charger;
        private System.Windows.Forms.TextBox nomFichier_;
        private System.Windows.Forms.Label NomFichier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button neww;
    }
}

