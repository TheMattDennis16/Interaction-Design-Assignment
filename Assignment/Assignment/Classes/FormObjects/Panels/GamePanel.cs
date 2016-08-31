using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment.Classes.Panels
{
    class GamePanel
    {
        private static Form1 frm = (Form1)Application.OpenForms["Form1"];

        public static void startGame()
        {
            #region Panel Declaration
            string resolution = frm.getResolution();
            Dictionary<string, dynamic> formObj = new Dictionary<string, dynamic>();
            string[] dimensions = resolution.Split('x');
            #endregion

            #region Screen Object Declaraton & Definition
            frm.Click += Background_Click;
            frm.MouseMove += NewPnl_MouseMove;
            frm.BackgroundImageLayout = ImageLayout.Center;

            FormObjects.ObjectSpecific.Oven oven = new FormObjects.ObjectSpecific.Oven();
            oven.setSize(resolution);

            FormObjects.ObjectSpecific.TaskListBox tasks = new FormObjects.ObjectSpecific.TaskListBox();
            tasks.setSize(resolution);
            tasks.frmObj.BackColor = Color.White;

            FormObjects.ObjectSpecific.Caketin caketin = new FormObjects.ObjectSpecific.Caketin();
            caketin.setSize(resolution);

            FormObjects.ObjectSpecific.Butter butter = new FormObjects.ObjectSpecific.Butter();
            butter.setSize(resolution);

            FormObjects.ObjectSpecific.ChocolateBar chocoate = new FormObjects.ObjectSpecific.ChocolateBar();
            chocoate.setSize(resolution);

            FormObjects.ObjectSpecific.InteractionMarker marker = new FormObjects.ObjectSpecific.InteractionMarker();
            marker.setSize(resolution);
            marker.setPosition(-50, -50);

            FormObjects.ObjectSpecific.MeltingBowl meltingBowl = new FormObjects.ObjectSpecific.MeltingBowl();
            meltingBowl.setSize(resolution);

            FormObjects.ObjectSpecific.MeasuringJug measuringJug = new FormObjects.ObjectSpecific.MeasuringJug();
            measuringJug.setSize(resolution);

            FormObjects.ObjectSpecific.InstantCoffee instantCoffee = new FormObjects.ObjectSpecific.InstantCoffee();
            instantCoffee.setSize(resolution);

            FormObjects.ObjectSpecific.Sink sink = new FormObjects.ObjectSpecific.Sink();
            sink.setSize(resolution);

            FormObjects.ObjectSpecific.Flour flour = new FormObjects.ObjectSpecific.Flour();
            flour.setSize(resolution);

            FormObjects.ObjectSpecific.Scales scales = new FormObjects.ObjectSpecific.Scales();
            scales.setSize(resolution);

            FormObjects.ObjectSpecific.MixingBowl mixing = new FormObjects.ObjectSpecific.MixingBowl();
            mixing.setSize(resolution);

            FormObjects.ObjectSpecific.Soda soda = new FormObjects.ObjectSpecific.Soda();
            soda.setSize(resolution);

            FormObjects.ObjectSpecific.Eggbox eggbox = new FormObjects.ObjectSpecific.Eggbox();
            eggbox.setSize(resolution);

            FormObjects.ObjectSpecific.Sugar sugar = new FormObjects.ObjectSpecific.Sugar();
            sugar.setSize(resolution);

            FormObjects.ObjectSpecific.ButterMilk buttermilk = new FormObjects.ObjectSpecific.ButterMilk();
            buttermilk.setSize(resolution);

            FormObjects.ObjectSpecific.Mixer mixer = new FormObjects.ObjectSpecific.Mixer();
            mixer.setSize(resolution);

            FormObjects.ObjectSpecific.Knife knife = new FormObjects.ObjectSpecific.Knife();
            knife.setSize(resolution);

            FormObjects.ObjectSpecific.CoveringBowl covering = new FormObjects.ObjectSpecific.CoveringBowl();
            covering.setSize(resolution);

            FormObjects.ObjectSpecific.Cream cream = new FormObjects.ObjectSpecific.Cream();
            cream.setSize(resolution);

            FormObjects.ObjectSpecific.Cocoa cocoa = new FormObjects.ObjectSpecific.Cocoa();
            cocoa.setSize(resolution);
            #endregion

            #region Resolution Changer
            if (resolution == "1280x720")
            {
                frm.BackgroundImage = Properties.Resources.Background_1280x720;
                oven.setPosition(1020, 430);
                tasks.setPosition(1025, 57);
                caketin.setPosition(820, 415);
                butter.setPosition(110, 20);
                chocoate.setPosition(290, 20);
                meltingBowl.setPosition(240, 415);
                measuringJug.setPosition(415, 415);
                instantCoffee.setPosition(450, 5);
                sink.setPosition(0, 375);
                flour.setPosition(625, 15);
                scales.setPosition(540, 415);
                mixing.setPosition(650, 415);
                soda.setPosition(800, 20);
                eggbox.setPosition(110, 120);
                sugar.setPosition(310, 130);
                buttermilk.setPosition(460, 120);
                mixer.setPosition(625, 130);
                knife.setPosition(790, 150);
                cocoa.setPosition(450, 240);
                covering.setPosition(110, 240);
                cream.setPosition(310, 240);
            }
            else if (resolution == "800x600")
            {
                frm.BackgroundImage = Properties.Resources.Background_800x600;
                oven.setPosition(620, 400);
                tasks.setPosition(595, 50);
                caketin.setPosition(555, 328);
                butter.setPosition(50, 15);
                chocoate.setPosition(160, 20);
                meltingBowl.setPosition(170, 328);
                measuringJug.setPosition(270,328);
                instantCoffee.setPosition(270, 0);
                sink.setPosition(10, 328);
                flour.setPosition(400, 0);
                scales.setPosition(360, 328);
                mixing.setPosition(450, 328);
                soda.setPosition(400, 190);
                eggbox.setPosition(30, 110);
                sugar.setPosition(160, 110);
                buttermilk.setPosition(270, 110);
                cocoa.setPosition(270, 190);
                mixer.setPosition(400, 110);
                knife.setPosition(480, 110);
                covering.setPosition(60, 200);
                cream.setPosition(160, 190);
            }
            frm.Controls.Add(oven.frmObj);
            frm.Controls.Add(tasks.frmObj);
            frm.Controls.Add(caketin.frmObj);
            frm.Controls.Add(butter.frmObj);
            frm.Controls.Add(chocoate.frmObj);
            frm.Controls.Add(marker.frmObj);
            frm.Controls.Add(meltingBowl.frmObj);
            frm.Controls.Add(measuringJug.frmObj);
            frm.Controls.Add(instantCoffee.frmObj);
            frm.Controls.Add(sink.frmObj);
            frm.Controls.Add(flour.frmObj);
            frm.Controls.Add(scales.frmObj);
            frm.Controls.Add(mixing.frmObj);
            frm.Controls.Add(soda.frmObj);
            frm.Controls.Add(eggbox.frmObj);
            frm.Controls.Add(sugar.frmObj);
            frm.Controls.Add(buttermilk.frmObj);
            frm.Controls.Add(mixer.frmObj);
            frm.Controls.Add(knife.frmObj);
            frm.Controls.Add(covering.frmObj);
            frm.Controls.Add(cream.frmObj);
            frm.Controls.Add(cocoa.frmObj);
            formObj.Add("oven", oven);
            formObj.Add("tasks", tasks);
            formObj.Add("caketin", caketin);
            formObj.Add("butter", butter);
            formObj.Add("chocolate", chocoate);
            formObj.Add("marker", marker);
            formObj.Add("meltingBowl", meltingBowl);
            formObj.Add("measuringJug", measuringJug);
            formObj.Add("instantCoffee", instantCoffee);
            formObj.Add("sink", sink);
            formObj.Add("flour", flour);
            formObj.Add("scales", scales);
            formObj.Add("mixingBowl", mixing);
            formObj.Add("soda", soda);
            formObj.Add("eggbox", eggbox);
            formObj.Add("sugar", sugar);
            formObj.Add("buttermilk", buttermilk);
            formObj.Add("mixer", mixing);
            formObj.Add("knife", knife);
            formObj.Add("coveringBowl", covering);
            formObj.Add("cream", cream);
            formObj.Add("cocoa", cocoa);
            frm.formObj = formObj;
            #endregion
        }

        private static void NewPnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (InterfaceObjects.ItemBinding.hasBoundItem())
            {
                InterfaceObjects.ItemBinding.getBoundItem().Location = frm.PointToClient(new Point((Cursor.Position.X + 10), (Cursor.Position.Y + 10)));
            }
        }

        private static void Background_Click(object sender, EventArgs e)
        {
            InterfaceObjects.ItemBinding.unbindItem();
        }
    }
}
