using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Rubik_Cube
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        Matrix viewMatrix;
        Matrix projectionMatrix;
        Matrix reflectionViewMatrix;

        Vector3 cameraPosition = new Vector3(20, 0, 0);
        float leftrightRot = 1.68f;
        float updownRot = 0.02f;
        const float rotationSpeed = 0.3f;
        const float moveSpeed = 30.0f;
        MouseState originalMouseState;
    
        Effect ColorEffect;

        Manager ManagerRef;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            graphics.ApplyChanges();
            Window.Title = "Rubik's Cube";
            ManagerRef = new Manager();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ColorEffect = Content.Load<Effect>("ReplaceColor");
            spriteFont = Content.Load<SpriteFont>("hudFont");

            //UpdateViewMatrix();
            viewMatrix = Matrix.CreateLookAt(new Vector3(0, 10, 0), new Vector3(0,10,0), Vector3.Up);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), GraphicsDevice.Viewport.AspectRatio, 0.3f, 1000.0f);

            Mouse.SetPosition(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            originalMouseState = Mouse.GetState();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 9; j++)
                {                    
                    ManagerRef.Faces[i,j].PieceModel = Content.Load<Model>("Box");
                    foreach (ModelMesh mesh in ManagerRef.Faces[i, j].PieceModel.Meshes)
                    {
                        foreach (ModelMeshPart part in mesh.MeshParts)
                        {
                            part.Effect = ColorEffect;
                        }
                    }
                }
            }
        }

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            float timeDifference = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
            ProcessInput(timeDifference);
            base.Update(gameTime);
        }

        public bool  Test = false;
        private void ProcessInput(float amount)
        {
            Vector3 moveVector = new Vector3(0, 0, 0);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), GraphicsDevice.Viewport.AspectRatio, 0.3f, 10000.0f);

                MouseState currentMouseState = Mouse.GetState();
                KeyboardState keyState = Keyboard.GetState();
                if (currentMouseState != originalMouseState)
                {
                    float xDifference = currentMouseState.X - originalMouseState.X;
                    float yDifference = currentMouseState.Y - originalMouseState.Y;
                    leftrightRot -= rotationSpeed * xDifference * amount;
                    updownRot -= rotationSpeed * yDifference * amount;
                    Mouse.SetPosition(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
                    UpdateViewMatrix();
                }               

                if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up) || keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
                {
                    moveVector += new Vector3(0, 0, -1);
                }
                if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down) || keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S))
                    moveVector += new Vector3(0, 0, 1);
                if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right) || keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D))
                    moveVector += new Vector3(1, 0, 0);
                if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left) || keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A))
                    moveVector += new Vector3(-1, 0, 0);
                if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Q))
                    moveVector += new Vector3(0, 1, 0);
                if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z))
                    moveVector += new Vector3(0, -1, 0);
                if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.T))
                {
                    Test = true;
                }
                if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Y))
                {
                    Test = false;
                }
                if (!Test)
                    AddToCameraPosition(moveVector * amount);
                        
        }

        private void AddToCameraPosition(Vector3 vectorToAdd)
        {
            Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(leftrightRot);
            Vector3 rotatedVector = Vector3.Transform(vectorToAdd, cameraRotation);
            cameraPosition += moveSpeed * rotatedVector;
            UpdateViewMatrix();
        }

        private void UpdateViewMatrix()
        {
            Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(leftrightRot);

            Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
            Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);
            Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            Vector3 cameraFinalTarget = cameraPosition + cameraRotatedTarget;
            Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);

            viewMatrix = Matrix.CreateLookAt(cameraPosition, cameraFinalTarget, cameraRotatedUpVector);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.DepthStencilState = DepthStencilState.DepthRead;
            GraphicsDevice.BlendState = BlendState.NonPremultiplied;

            for (int i = 0; i < 6; i++)
            {                
                for (int j = 0; j < 9; j++)
                {
                    switch (i)
                    {
                        case 0: ManagerRef.Faces[i, j].Orientation = Matrix.CreateRotationY(MathHelper.ToRadians(0));
                            break;
                        case 1: ManagerRef.Faces[i, j].Orientation = Matrix.CreateRotationY(MathHelper.ToRadians(90 * i)) * Matrix.CreateTranslation(new Vector3(ManagerRef.Faces[i, j].X * -10, 0, ManagerRef.Faces[i, j].X * -10));
                            break;
                        case 2: ManagerRef.Faces[i, j].Orientation = Matrix.CreateRotationY(MathHelper.ToRadians(90 * i)) * Matrix.CreateTranslation(new Vector3(0, 0, -20));
                            break;
                        case 3: ManagerRef.Faces[i, j].Orientation = Matrix.CreateRotationY(MathHelper.ToRadians(90 * i)) * Matrix.CreateTranslation(new Vector3((2-ManagerRef.Faces[i, j].X) * 10, 0, (2-ManagerRef.Faces[i, j].X) * -10));
                            break;
                        case 4: ManagerRef.Faces[i, j].Orientation = Matrix.CreateRotationY(MathHelper.ToRadians(90 * i)) * Matrix.CreateTranslation(new Vector3(0, (2-ManagerRef.Faces[i, j].Y) * 10, ManagerRef.Faces[i, j].Y * -10));
                            break;
                        case 5: ManagerRef.Faces[i, j].Orientation = Matrix.CreateRotationY(MathHelper.ToRadians(90 * i))  * Matrix.CreateTranslation(new Vector3(0,ManagerRef.Faces[i, j].Y * -10, ManagerRef.Faces[i, j].Y * -10));
                            break;  
                    }                   
                     
                    ManagerRef.Faces[i, j].ProjectionMatrix = projectionMatrix;
                    ManagerRef.Faces[i, j].ViewMatrix = viewMatrix;
                    DrawPiece(ManagerRef.Faces[i, j]);
                }                
            }
            base.Draw(gameTime);
        }

        public void DrawPiece(Piece obj)
        {
            Matrix[] boneTransforms = new Matrix[obj.PieceModel.Bones.Count];
            obj.PieceModel.CopyAbsoluteBoneTransformsTo(boneTransforms);

            foreach (KeyValuePair<Direction,Color> item in obj.Colors)
            {
                foreach (ModelMesh mesh in obj.PieceModel.Meshes)
                {
                    Matrix worldMatrix = boneTransforms[mesh.ParentBone.Index] * Matrix.CreateScale(0.001f) * obj.Orientation * Matrix.CreateTranslation(new Vector3(obj.X * 10, obj.Y * 10, 0));
                        
                    foreach (Effect effect in mesh.Effects)
                    {
                        BasicEffect basicEffect = effect as BasicEffect;
                        if (basicEffect!=null)
                        {
                            basicEffect.EnableDefaultLighting();

                            basicEffect.World = worldMatrix;
                            basicEffect.View = obj.ViewMatrix;
                            basicEffect.Projection = obj.ProjectionMatrix;

                            basicEffect.PreferPerPixelLighting = true;
                        }
                        else
                        {
                            effect.Parameters["WorldViewProjection"].SetValue(worldMatrix * obj.ViewMatrix * obj.ProjectionMatrix);
                            effect.Parameters["World"].SetValue(worldMatrix);
                            effect.Parameters["TargetColor"].SetValue(item.Value.ToVector3());
                        }                        
                    }
                    mesh.Draw();
                }
            }           
        }
    }
}
