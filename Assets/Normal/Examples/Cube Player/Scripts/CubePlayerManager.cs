using UnityEngine;
using Normal.Realtime;

namespace Normal.Realtime.Examples
{
    public class CubePlayerManager : MonoBehaviour
    {
        private Realtime _realtime;
        public GameObject playerPrefab;

        private void Awake()
        {
            // Get the Realtime component on this game object
            _realtime = GetComponent<Realtime>();

            // Notify us when Realtime successfully connects to the room
            _realtime.didConnectToRoom += DidConnectToRoom;
        }

        private void DidConnectToRoom(Realtime realtime)
        {
            string prefabName = playerPrefab.transform.name;

            Vector3 randomLoc = new Vector3(Random.Range(-80f, 80f), 1f, Random.Range(-80f, 80f));
            // Instantiate the CubePlayer for this client once we've successfully connected to the room
            Realtime.Instantiate(prefabName,                 // Prefab name
                                position: randomLoc,          // Start 1 meter in the air
                                rotation: Quaternion.identity, // No rotation
                           ownedByClient: true,                // Make sure the RealtimeView on this prefab is owned by this client
                preventOwnershipTakeover: true,                // Prevent other clients from calling RequestOwnership() on the root RealtimeView.
                             useInstance: realtime);           // Use the instance of Realtime that fired the didConnectToRoom event.
        }
    }
}
