namespace 集成.panel
{
    partial class CutPicture
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CutPicture));
            this.cut = new CCWin.SkinControl.SkinButton();
            this.save_data = new CCWin.SkinControl.SkinButton();
            this.creat_xml = new CCWin.SkinControl.SkinButton();
            this.backout = new CCWin.SkinControl.SkinButton();
            this.choose_Pic = new CCWin.SkinControl.SkinButton();
            this.all_thing_isOk = new CCWin.SkinControl.SkinButton();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.skinButton3 = new CCWin.SkinControl.SkinButton();
            this.skinButton2 = new CCWin.SkinControl.SkinButton();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.chk_begin_paint_line = new CCWin.SkinControl.SkinCheckBox();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.cut_isOk = new CCWin.SkinControl.SkinButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.show_pic = new CCWin.SkinControl.SkinPictureBox();
            this.skinPanel1.SuspendLayout();
            this.skinPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // cut
            // 
            this.cut.BackColor = System.Drawing.Color.Transparent;
            this.cut.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.cut.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cut.DownBack = ((System.Drawing.Image)(resources.GetObject("cut.DownBack")));
            this.cut.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.cut.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cut.Location = new System.Drawing.Point(612, 18);
            this.cut.MouseBack = ((System.Drawing.Image)(resources.GetObject("cut.MouseBack")));
            this.cut.Name = "cut";
            this.cut.NormlBack = ((System.Drawing.Image)(resources.GetObject("cut.NormlBack")));
            this.cut.Size = new System.Drawing.Size(69, 24);
            this.cut.TabIndex = 145;
            this.cut.Text = "切割";
            this.cut.UseVisualStyleBackColor = false;
            this.cut.Visible = false;
            this.cut.Click += new System.EventHandler(this.cut_Click);
            // 
            // save_data
            // 
            this.save_data.BackColor = System.Drawing.Color.Transparent;
            this.save_data.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.save_data.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.save_data.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.save_data.DownBack = ((System.Drawing.Image)(resources.GetObject("save_data.DownBack")));
            this.save_data.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.save_data.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.save_data.Location = new System.Drawing.Point(503, 18);
            this.save_data.MouseBack = ((System.Drawing.Image)(resources.GetObject("save_data.MouseBack")));
            this.save_data.Name = "save_data";
            this.save_data.NormlBack = ((System.Drawing.Image)(resources.GetObject("save_data.NormlBack")));
            this.save_data.Size = new System.Drawing.Size(80, 24);
            this.save_data.TabIndex = 144;
            this.save_data.Text = "添加到XML";
            this.save_data.UseVisualStyleBackColor = false;
            this.save_data.Visible = false;
            this.save_data.Click += new System.EventHandler(this.save_data_Click);
            // 
            // creat_xml
            // 
            this.creat_xml.BackColor = System.Drawing.Color.Transparent;
            this.creat_xml.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.creat_xml.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.creat_xml.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.creat_xml.DownBack = ((System.Drawing.Image)(resources.GetObject("creat_xml.DownBack")));
            this.creat_xml.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.creat_xml.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.creat_xml.Location = new System.Drawing.Point(405, 18);
            this.creat_xml.MouseBack = ((System.Drawing.Image)(resources.GetObject("creat_xml.MouseBack")));
            this.creat_xml.Name = "creat_xml";
            this.creat_xml.NormlBack = ((System.Drawing.Image)(resources.GetObject("creat_xml.NormlBack")));
            this.creat_xml.Size = new System.Drawing.Size(69, 24);
            this.creat_xml.TabIndex = 143;
            this.creat_xml.Text = "生成XML";
            this.creat_xml.UseVisualStyleBackColor = false;
            this.creat_xml.Visible = false;
            this.creat_xml.Click += new System.EventHandler(this.creat_xml_Click);
            // 
            // backout
            // 
            this.backout.BackColor = System.Drawing.Color.Transparent;
            this.backout.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.backout.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.backout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.backout.DownBack = ((System.Drawing.Image)(resources.GetObject("backout.DownBack")));
            this.backout.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.backout.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.backout.Location = new System.Drawing.Point(1002, 19);
            this.backout.MouseBack = ((System.Drawing.Image)(resources.GetObject("backout.MouseBack")));
            this.backout.Name = "backout";
            this.backout.NormlBack = ((System.Drawing.Image)(resources.GetObject("backout.NormlBack")));
            this.backout.Size = new System.Drawing.Size(69, 24);
            this.backout.TabIndex = 142;
            this.backout.Text = "撤销线条";
            this.backout.UseVisualStyleBackColor = false;
            this.backout.Click += new System.EventHandler(this.backout_Click);
            // 
            // choose_Pic
            // 
            this.choose_Pic.BackColor = System.Drawing.Color.Transparent;
            this.choose_Pic.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.choose_Pic.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.choose_Pic.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.choose_Pic.DownBack = ((System.Drawing.Image)(resources.GetObject("choose_Pic.DownBack")));
            this.choose_Pic.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.choose_Pic.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.choose_Pic.Location = new System.Drawing.Point(111, 18);
            this.choose_Pic.MouseBack = ((System.Drawing.Image)(resources.GetObject("choose_Pic.MouseBack")));
            this.choose_Pic.Name = "choose_Pic";
            this.choose_Pic.NormlBack = ((System.Drawing.Image)(resources.GetObject("choose_Pic.NormlBack")));
            this.choose_Pic.Size = new System.Drawing.Size(69, 24);
            this.choose_Pic.TabIndex = 140;
            this.choose_Pic.Text = "选择图片";
            this.choose_Pic.UseVisualStyleBackColor = false;
            this.choose_Pic.Click += new System.EventHandler(this.choose_Pic_Click);
            // 
            // all_thing_isOk
            // 
            this.all_thing_isOk.BackColor = System.Drawing.Color.Transparent;
            this.all_thing_isOk.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.all_thing_isOk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.all_thing_isOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.all_thing_isOk.DownBack = ((System.Drawing.Image)(resources.GetObject("all_thing_isOk.DownBack")));
            this.all_thing_isOk.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.all_thing_isOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.all_thing_isOk.Location = new System.Drawing.Point(307, 18);
            this.all_thing_isOk.MouseBack = ((System.Drawing.Image)(resources.GetObject("all_thing_isOk.MouseBack")));
            this.all_thing_isOk.Name = "all_thing_isOk";
            this.all_thing_isOk.NormlBack = ((System.Drawing.Image)(resources.GetObject("all_thing_isOk.NormlBack")));
            this.all_thing_isOk.Size = new System.Drawing.Size(69, 24);
            this.all_thing_isOk.TabIndex = 141;
            this.all_thing_isOk.Text = "完成准备";
            this.all_thing_isOk.UseVisualStyleBackColor = false;
            this.all_thing_isOk.Visible = false;
            this.all_thing_isOk.Click += new System.EventHandler(this.all_thing_isOk_Click);
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.comboBox1);
            this.skinPanel1.Controls.Add(this.skinButton3);
            this.skinPanel1.Controls.Add(this.skinButton2);
            this.skinPanel1.Controls.Add(this.skinButton1);
            this.skinPanel1.Controls.Add(this.chk_begin_paint_line);
            this.skinPanel1.Controls.Add(this.skinLabel6);
            this.skinPanel1.Controls.Add(this.backout);
            this.skinPanel1.Controls.Add(this.skinLabel5);
            this.skinPanel1.Controls.Add(this.skinLabel4);
            this.skinPanel1.Controls.Add(this.skinLabel3);
            this.skinPanel1.Controls.Add(this.skinLabel2);
            this.skinPanel1.Controls.Add(this.cut_isOk);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.Controls.Add(this.cut);
            this.skinPanel1.Controls.Add(this.save_data);
            this.skinPanel1.Controls.Add(this.all_thing_isOk);
            this.skinPanel1.Controls.Add(this.creat_xml);
            this.skinPanel1.Controls.Add(this.choose_Pic);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(12, 12);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(1168, 57);
            this.skinPanel1.TabIndex = 146;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1077, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(91, 20);
            this.comboBox1.TabIndex = 157;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // skinButton3
            // 
            this.skinButton3.BackColor = System.Drawing.Color.Transparent;
            this.skinButton3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButton3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.skinButton3.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton3.DownBack")));
            this.skinButton3.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton3.Location = new System.Drawing.Point(846, 18);
            this.skinButton3.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton3.MouseBack")));
            this.skinButton3.Name = "skinButton3";
            this.skinButton3.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton3.NormlBack")));
            this.skinButton3.Size = new System.Drawing.Size(69, 24);
            this.skinButton3.TabIndex = 156;
            this.skinButton3.Text = "下一页";
            this.skinButton3.UseVisualStyleBackColor = false;
            this.skinButton3.Visible = false;
            this.skinButton3.Click += new System.EventHandler(this.skinButton3_Click);
            // 
            // skinButton2
            // 
            this.skinButton2.BackColor = System.Drawing.Color.Transparent;
            this.skinButton2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.skinButton2.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton2.DownBack")));
            this.skinButton2.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton2.Location = new System.Drawing.Point(771, 18);
            this.skinButton2.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton2.MouseBack")));
            this.skinButton2.Name = "skinButton2";
            this.skinButton2.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton2.NormlBack")));
            this.skinButton2.Size = new System.Drawing.Size(69, 24);
            this.skinButton2.TabIndex = 155;
            this.skinButton2.Text = "全部切割";
            this.skinButton2.UseVisualStyleBackColor = false;
            this.skinButton2.Visible = false;
            this.skinButton2.Click += new System.EventHandler(this.skinButton2_Click);
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.skinButton1.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton1.DownBack")));
            this.skinButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton1.Location = new System.Drawing.Point(696, 18);
            this.skinButton1.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton1.MouseBack")));
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton1.NormlBack")));
            this.skinButton1.Size = new System.Drawing.Size(69, 24);
            this.skinButton1.TabIndex = 154;
            this.skinButton1.Text = "清除废弃图片";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Visible = false;
            this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // chk_begin_paint_line
            // 
            this.chk_begin_paint_line.AutoSize = true;
            this.chk_begin_paint_line.BackColor = System.Drawing.Color.Transparent;
            this.chk_begin_paint_line.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.chk_begin_paint_line.DefaultCheckButtonWidth = 17;
            this.chk_begin_paint_line.DownBack = ((System.Drawing.Image)(resources.GetObject("chk_begin_paint_line.DownBack")));
            this.chk_begin_paint_line.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_begin_paint_line.ForeColor = System.Drawing.Color.Black;
            this.chk_begin_paint_line.LightEffect = false;
            this.chk_begin_paint_line.Location = new System.Drawing.Point(921, 22);
            this.chk_begin_paint_line.MouseBack = ((System.Drawing.Image)(resources.GetObject("chk_begin_paint_line.MouseBack")));
            this.chk_begin_paint_line.Name = "chk_begin_paint_line";
            this.chk_begin_paint_line.NormlBack = ((System.Drawing.Image)(resources.GetObject("chk_begin_paint_line.NormlBack")));
            this.chk_begin_paint_line.SelectedDownBack = ((System.Drawing.Image)(resources.GetObject("chk_begin_paint_line.SelectedDownBack")));
            this.chk_begin_paint_line.SelectedMouseBack = ((System.Drawing.Image)(resources.GetObject("chk_begin_paint_line.SelectedMouseBack")));
            this.chk_begin_paint_line.SelectedNormlBack = ((System.Drawing.Image)(resources.GetObject("chk_begin_paint_line.SelectedNormlBack")));
            this.chk_begin_paint_line.Size = new System.Drawing.Size(75, 21);
            this.chk_begin_paint_line.TabIndex = 153;
            this.chk_begin_paint_line.Text = "开始划线";
            this.chk_begin_paint_line.UseVisualStyleBackColor = false;
            this.chk_begin_paint_line.CheckedChanged += new System.EventHandler(this.chk_begin_paint_line_CheckedChanged);
            // 
            // skinLabel6
            // 
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.Location = new System.Drawing.Point(589, 22);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(17, 17);
            this.skinLabel6.TabIndex = 152;
            this.skinLabel6.Text = ">";
            this.skinLabel6.Visible = false;
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(480, 22);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(17, 17);
            this.skinLabel5.TabIndex = 151;
            this.skinLabel5.Text = ">";
            this.skinLabel5.Visible = false;
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(382, 22);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(17, 17);
            this.skinLabel4.TabIndex = 150;
            this.skinLabel4.Text = ">";
            this.skinLabel4.Visible = false;
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(284, 22);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(17, 17);
            this.skinLabel3.TabIndex = 149;
            this.skinLabel3.Text = ">";
            this.skinLabel3.Visible = false;
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(186, 22);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(17, 17);
            this.skinLabel2.TabIndex = 148;
            this.skinLabel2.Text = ">";
            this.skinLabel2.Visible = false;
            // 
            // cut_isOk
            // 
            this.cut_isOk.BackColor = System.Drawing.Color.Transparent;
            this.cut_isOk.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.cut_isOk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cut_isOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cut_isOk.DownBack = ((System.Drawing.Image)(resources.GetObject("cut_isOk.DownBack")));
            this.cut_isOk.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.cut_isOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cut_isOk.Location = new System.Drawing.Point(209, 18);
            this.cut_isOk.MouseBack = ((System.Drawing.Image)(resources.GetObject("cut_isOk.MouseBack")));
            this.cut_isOk.Name = "cut_isOk";
            this.cut_isOk.NormlBack = ((System.Drawing.Image)(resources.GetObject("cut_isOk.NormlBack")));
            this.cut_isOk.Size = new System.Drawing.Size(69, 24);
            this.cut_isOk.TabIndex = 147;
            this.cut_isOk.Text = "确认分割";
            this.cut_isOk.UseVisualStyleBackColor = false;
            this.cut_isOk.Visible = false;
            this.cut_isOk.Click += new System.EventHandler(this.cut_isOk_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.skinLabel1.Location = new System.Drawing.Point(25, 22);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(56, 17);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "切图过程";
            // 
            // skinPanel2
            // 
            this.skinPanel2.AutoScroll = true;
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.show_pic);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(13, 76);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(1167, 575);
            this.skinPanel2.TabIndex = 147;
            // 
            // show_pic
            // 
            this.show_pic.BackColor = System.Drawing.Color.Transparent;
            this.show_pic.Location = new System.Drawing.Point(4, 4);
            this.show_pic.Name = "show_pic";
            this.show_pic.Size = new System.Drawing.Size(1160, 568);
            this.show_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.show_pic.TabIndex = 0;
            this.show_pic.TabStop = false;
            this.show_pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_MouseDown);
            this.show_pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // CutPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1192, 663);
            this.Controls.Add(this.skinPanel2);
            this.Controls.Add(this.skinPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CutPicture";
            this.Text = "CutPicture";
            this.Load += new System.EventHandler(this.CutPicture_Load);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.skinPanel2.ResumeLayout(false);
            this.skinPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton cut;
        private CCWin.SkinControl.SkinButton save_data;
        private CCWin.SkinControl.SkinButton creat_xml;
        private CCWin.SkinControl.SkinButton backout;
        private CCWin.SkinControl.SkinButton choose_Pic;
        private CCWin.SkinControl.SkinButton all_thing_isOk;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinButton cut_isOk;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private CCWin.SkinControl.SkinPanel skinPanel2;
        private CCWin.SkinControl.SkinPictureBox show_pic;
        private CCWin.SkinControl.SkinCheckBox chk_begin_paint_line;
        private CCWin.SkinControl.SkinButton skinButton1;
        private CCWin.SkinControl.SkinButton skinButton2;
        private CCWin.SkinControl.SkinButton skinButton3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}