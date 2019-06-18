using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PvZInitial
{
  public class PlaySound : MonoBehaviour
  {
    private List<AudioSource> listCurAudioPlaying = new List<AudioSource>();


    public void Play(AudioClip audioClip)
    {
      GameObject newAudioSourceGO = new GameObject();
      AudioSource newAudioSource = newAudioSourceGO.AddComponent<AudioSource>();
      newAudioSourceGO.transform.SetParent(ContainerObjectServiceLocator.Instance.audio);
      newAudioSourceGO.name = audioClip.ToString();

      newAudioSource.loop = false;
      newAudioSource.playOnAwake = true;

      newAudioSource.clip = audioClip;

      newAudioSource.Play();


      listCurAudioPlaying.Add(newAudioSource);

      StartCoroutine(WaitForClipToFinish(newAudioSource));

    }

    IEnumerator WaitForClipToFinish(AudioSource audioSource)
    {
      yield return new WaitUntil(() => audioSource.isPlaying == false);

      listCurAudioPlaying.Remove(audioSource);
      Destroy(audioSource.gameObject);


    }
  }
}