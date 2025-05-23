﻿using System;
using System.Linq;
using UnityEditor;

using UnityEngine;
using Object = UnityEngine.Object;

namespace AssetUsageFinder {
    [Serializable]
    sealed class InStageDependencyFinder : DependencyAbstractFinder {
        [SerializeField] string _stagePath;
        [SerializeField] UnityEditor.SceneManagement.PrefabStage _stage;

        public InStageDependencyFinder(Object target, string stagePath) {
            Target = SearchTarget.CreateStage(target, stagePath);
            _stagePath = stagePath;
            _stage = Target.Stage;
            Title = stagePath;

            var name = target is Component ? target.GetType().Name : target.name;

            TabContent = new GUIContent {
                text = name,
                image = AssetPreview.GetMiniTypeThumbnail(Target.Target.GetType()) ?? AssetPreview.GetMiniThumbnail(Target.Target)
            };

            FindDependencies();
        }

        public override void FindDependencies() {
            Dependencies = Group(DependencyFinderEngine.GetDependenciesInStage(Target, _stage)).ToArray();
        }


        public override DependencyAbstractFinder Nest(Object o) {
            return new InStageDependencyFinder(o, _stagePath) {Parent = this};
        }
    }
}