using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
	[SerializeField] private EventManager eventManager;
	[SerializeField] private GameObject dummyRobot;
	[SerializeField] private GameObject tablet;
	[SerializeField] private Text nameText;
	[SerializeField] private Text orderItemsText;
	[SerializeField] private GameObject map;
	[SerializeField] private AudioSource orderNotificationSoundEffect;
	[SerializeField] private AudioSource clickSoundEffect;
	[SerializeField] private Animator tablePopUp;

	[SerializeField] private OrderTrigger orderTrigger;

	private string orderer;
	private string items;

	private bool startPlay = false;

	void Awake()
	{

	}

	public List<Item> getOrder()
    {
		return orderTrigger.getOrderItems();
	}

	public void StartOrder(Order itemsList)
	{
		reset();

		tablePopUp.SetBool("pop", true);
		
		orderer = itemsList.getName();
		items = itemsList.getItemsList();
		map = itemsList.getMap();

		DisplayOrder();
	}

	public void DisplayOrder()
	{
		orderNotificationSoundEffect.Play();
		nameText.text = orderer;

		orderItemsText.text = "";

		StopAllCoroutines();
		StartCoroutine(TypeSentence(items));
	}

	IEnumerator TypeSentence(string sentence)
	{	
		foreach (char letter in sentence.ToCharArray())
		{
			orderItemsText.text += letter;
			yield return new WaitForSeconds(.02f);
		}
	}

	public void Next()
	{
		clickSoundEffect.Play();

		if (startPlay == false)
        {
			orderItemsText.gameObject.SetActive(false);
			map.SetActive(true);
			startPlay = true;
		}
        else
        {
			tablePopUp.SetBool("pop", false);
			map.SetActive(false);
			startPlay = false;
			dummyRobot.SetActive(true);
		}
		
	}

	private void reset()
    {
		dummyRobot.SetActive(false);
		orderItemsText.gameObject.SetActive(true);
		map.SetActive(false);
	}
}
