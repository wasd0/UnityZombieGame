using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject.Internal;
using Assert = ModestTree.Assert;

// Ignore warning about using SceneManager.UnloadScene instead of SceneManager.UnloadSceneAsync
#pragma warning disable 618

namespace Zenject
{
    public abstract class SceneTestFixture
    {
        private readonly List<DiContainer> _sceneContainers = new List<DiContainer>();

        private bool _hasLoadedScene;

        protected DiContainer SceneContainer { get; private set; }

        protected IEnumerable<DiContainer> SceneContainers => _sceneContainers;

        public IEnumerator LoadScene(string sceneName)
        {
            return LoadScenes(sceneName);
        }

        public IEnumerator LoadScenes(params string[] sceneNames)
        {
            Assert.That(!_hasLoadedScene, "Attempted to load scene twice!");
            _hasLoadedScene = true;

            // Clean up any leftovers from previous test
            ZenjectTestUtil.DestroyEverythingExceptTestRunner(false);

            Assert.That(SceneContainers.IsEmpty());

            for (var i = 0; i < sceneNames.Length; i++)
            {
                var sceneName = sceneNames[i];

                Assert.That(Application.CanStreamedLevelBeLoaded(sceneName),
                    "Cannot load scene '{0}' for test '{1}'.  The scenes used by SceneTestFixture derived classes must be added to the build settings for the test to work",
                    sceneName, GetType());

                Log.Info("Loading scene '{0}' for testing", sceneName);

                var loader =
                    SceneManager.LoadSceneAsync(sceneName, i == 0 ? LoadSceneMode.Single : LoadSceneMode.Additive);

                while (!loader.isDone) yield return null;

                SceneContext sceneContext = null;

                if (ProjectContext.HasInstance)
                    // ProjectContext might be null if scene does not have a scene context
                {
                    var scene = SceneManager.GetSceneByName(sceneName);

                    sceneContext = ProjectContext.Instance.Container.Resolve<SceneContextRegistry>()
                        .TryGetSceneContextForScene(scene);
                }

                _sceneContainers.Add(sceneContext == null ? null : sceneContext.Container);
            }

            SceneContainer = _sceneContainers.Where(x => x != null).LastOrDefault();

            if (SceneContainer != null) SceneContainer.Inject(this);
        }

        [SetUp]
        public virtual void SetUp()
        {
            StaticContext.Clear();
            SetMemberDefaults();
        }

        private void SetMemberDefaults()
        {
            _hasLoadedScene = false;
            SceneContainer = null;
            _sceneContainers.Clear();
        }

        [TearDown]
        public virtual void Teardown()
        {
            ZenjectTestUtil.DestroyEverythingExceptTestRunner(true);
            StaticContext.Clear();
            SetMemberDefaults();
        }
    }
}