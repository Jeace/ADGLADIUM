using UnityEngine;
using XInputDotNetPure; // Required in C#
using System.Collections;
using System.Collections.Generic;

public class XInput : MonoBehaviour
{
	bool playerIndexSet = false;
	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
	public float triggerSensitivity = 0.2f;

	public bool A, B, X, Y, LB, RB, LT, RT, START, BACK, LJOYB, RJOYB, UPPAD, DOWNPAD, LEFTPAD, RIGHTPAD = false;
	public float RJOYX, RJOYY, LJOYX, LJOYY = 0.0f;

    // Use this for initialization
	void Start()
    {
		keys.Add ("A", KeyCode.S);
		keys.Add ("B", KeyCode.D);
		keys.Add ("Y", KeyCode.Z);
		keys.Add ("X", KeyCode.Q);
		keys.Add ("RT", KeyCode.E);
		keys.Add ("LT", KeyCode.A);
		keys.Add ("LB", KeyCode.Alpha1);
		keys.Add ("RB", KeyCode.Alpha2);
		keys.Add ("START", KeyCode.Escape);
		keys.Add ("BACK", KeyCode.Backspace);
		keys.Add ("LJOYB", KeyCode.LeftShift);
		keys.Add ("RJOYB", KeyCode.LeftControl);
		keys.Add ("UPPAD", KeyCode.UpArrow);
		keys.Add ("LEFTPAD", KeyCode.LeftArrow);
		keys.Add ("RIGHTPAD", KeyCode.RightArrow);
		keys.Add ("DOWNPAD", KeyCode.DownArrow);
		keys.Add ("LJOYLEFT", KeyCode.LeftArrow);
		keys.Add ("LJOYRIGHT", KeyCode.RightArrow);
		keys.Add ("LJOYUP", KeyCode.UpArrow);
		keys.Add ("LJOYDOWN", KeyCode.DownArrow);
		keys.Add ("RJOYLEFT", KeyCode.F);
		keys.Add ("RJOYRIGHT", KeyCode.H);
		keys.Add ("RJOYUP", KeyCode.T);
		keys.Add ("RJOYDOWN", KeyCode.G);
    }

    // Update is called once per frame
	void Update()
    {
        // Find a PlayerIndex, for a single player game
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        state = GamePad.GetState(playerIndex);

		this.A = this.getA ();
		this.B = this.getB ();
		this.X = this.getX ();
		this.Y = this.getY ();

		
		this.LB = this.getLB ();
		this.RB = this.getRB ();

		if (this.getLT () > this.triggerSensitivity) {
			this.LT = true;
		} else {
			this.LT = false;
		}
		if (this.getRT () > this.triggerSensitivity) {
			this.RT = true;
		} else {
			this.RT = false;
		}

		this.START = this.getSTART ();
		this.BACK = this.getBACK ();

		this.LEFTPAD = this.getPADLEFT ();
		this.RIGHTPAD = this.getPADRIGHT ();
		this.DOWNPAD = this.getPADDOWN ();
		this.UPPAD = this.getPADUP ();

		this.LJOYB = this.getLJOYB ();
		this.RJOYB = this.getRJOYB ();

		this.LJOYX = this.getLX ();
		this.LJOYY = this.getLY ();
		this.RJOYX = this.getRX ();
		this.RJOYY = this.getRY ();

        prevState = state;
	}
	
	float getRX(){
		if (state.IsConnected && state.ThumbSticks.Right.X != 0) {
			return state.ThumbSticks.Right.X;		
		}else {
			KeyCode temp;
			keys.TryGetValue("RJOYLEFT", out temp);
			if(Input.GetKey(temp)){
				return -1.0f;
			}else{
				keys.TryGetValue("RJOYRIGHT", out temp);
				if(Input.GetKey(temp)){
					return 1.0f;
				}else{
					return 0.0f;
				}
			}
		}
	}
	
	float getRY(){
		if (state.IsConnected && state.ThumbSticks.Right.Y != 0) {
			return state.ThumbSticks.Right.Y;		
		}else {
			KeyCode temp;
			keys.TryGetValue("RJOYDOWN", out temp);
			if(Input.GetKey(temp)){
				return -1.0f;
			}else{
				keys.TryGetValue("RJOYUP", out temp);
				if(Input.GetKey(temp)){
					return 1.0f;
				}else{
					return 0.0f;
				}
			}
		}
	}
	
	float getLX(){
		if (state.IsConnected && state.ThumbSticks.Left.X != 0) {
			return state.ThumbSticks.Left.X;		
		}else {
			KeyCode temp;
			keys.TryGetValue("LJOYLEFT", out temp);
			if(Input.GetKey(temp)){
				return -1.0f;
			}else{
				keys.TryGetValue("LJOYRIGHT", out temp);
				if(Input.GetKey(temp)){
					return 1.0f;
				}else{
					return 0.0f;
				}
			}
		}
	}
	
	float getLY(){
		if (state.IsConnected && state.ThumbSticks.Left.Y != 0) {
			return state.ThumbSticks.Left.Y;		
		}else {
			KeyCode temp;
			keys.TryGetValue("LJOYDOWN", out temp);
			if(Input.GetKey(temp)){
				return -1.0f;
			}else{
				keys.TryGetValue("LJOYUP", out temp);
				if(Input.GetKey(temp)){
					return 1.0f;
				}else{
					return 0.0f;
				}
			}
		}
	}

	float getLT(){
		if (state.IsConnected && state.Triggers.Left > 0) {
			return state.Triggers.Left;		
		}else {
			KeyCode temp;
			keys.TryGetValue("LT", out temp);
			if(Input.GetKey(temp)){
				return 1.0f;
			}else{
				return 0.0f;
			}
		}
	}
	
	float getRT(){
		if (state.IsConnected && state.Triggers.Right > 0) {
			return state.Triggers.Right;		
		}else {
			KeyCode temp;
			keys.TryGetValue("RT", out temp);
			if(Input.GetKey(temp)){
				return 1.0f;
			}else{
				return 0.0f;
			}
		}
	}
	
	bool getPADUP(){
		if (state.IsConnected && state.DPad.Up == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("UPPAD", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getPADDOWN(){
		if (state.IsConnected && state.DPad.Down == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("DOWNPAD", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getPADRIGHT(){
		if (state.IsConnected && state.DPad.Right == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("RIGHTPAD", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getPADLEFT(){
		if (state.IsConnected && state.DPad.Left == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("LEFTPAD", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getSTART(){
		if (state.IsConnected && state.Buttons.Start == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("START", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getBACK(){
		if (state.IsConnected && state.Buttons.Back == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("BACK", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getLB(){
		if (state.IsConnected && state.Buttons.LeftShoulder == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("LB", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getRB(){
		if (state.IsConnected && state.Buttons.RightShoulder == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("RB", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getLJOYB(){
		if (state.IsConnected && state.Buttons.LeftStick == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("LJOYB", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getRJOYB(){
		if (state.IsConnected && state.Buttons.RightStick == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("RJOYB", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getA(){
		if (state.IsConnected && state.Buttons.A == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("A", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getB(){
		if (state.IsConnected && state.Buttons.B == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("B", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getY(){
		if (state.IsConnected && state.Buttons.Y == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("Y", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}
	
	bool getX(){
		if (state.IsConnected && state.Buttons.X == ButtonState.Pressed) {
			return true;		
		}else {
			KeyCode temp;
			keys.TryGetValue("X", out temp);
			if(Input.GetKey(temp)){
				return true;
			}else{
				return false;
			}
		}
	}



}
