namespace SUSHI
{
    partial class ActionParent
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionParent));
            this.errorProviderInvalid = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderValid = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProviderInvalid
            // 
            this.errorProviderInvalid.ContainerControl = this;
            // 
            // errorProviderValid
            // 
            this.errorProviderValid.ContainerControl = this;
            this.errorProviderValid.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProviderValid.Icon")));
            // 
            // ActionParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Name = "ActionParent";
            this.Size = new System.Drawing.Size(683, 616);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ErrorProvider errorProviderInvalid;
        protected System.Windows.Forms.ErrorProvider errorProviderValid;


    }
}
