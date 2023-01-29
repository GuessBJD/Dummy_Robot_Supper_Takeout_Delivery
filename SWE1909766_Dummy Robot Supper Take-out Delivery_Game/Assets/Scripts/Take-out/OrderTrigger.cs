using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OrderTrigger : MonoBehaviour
{
	[SerializeField] private OrderManager orderManager;
	[SerializeField] private Order itemsList;

	void Start()
	{
		itemsList.generateOrder();
		TriggerOrder();		
	}

	public void TriggerOrder()
	{
		orderManager.StartOrder(itemsList);
	}

	public List<Item> getOrderItems()
    {
		return itemsList.getItems();
	}

}
